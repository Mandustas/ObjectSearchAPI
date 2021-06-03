using AutoMapper;
using DataLayer.DTOs.ClusterPoint;
using DataLayer.DTOs.DetectedObjects;
using DataLayer.Models;
using DataLayer.Repositories.DetectedObjects;
using DataLayer.Repositories.Missions;
using DataLayer.Repositories.Operations;
using DataLayer.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjectSearchAPI.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DetectedObjectController : ControllerBase
    {
        private readonly IDetectedObjectRepository _detectedObjectRepository;
        private readonly IOperationsRepository _operationRepository;
        private readonly IMissionRepository _missionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IClusteringService _clusteringService;
        private readonly IMapper _mapper;
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public DetectedObjectController(
            IDetectedObjectRepository detectedObjectRepository,
            IOperationsRepository operationRepository,
            IMissionRepository missionRepository,
            IUserRepository userRepository,
            IClusteringService clusteringService,
            IMapper mapper
            )
        {
            _detectedObjectRepository = detectedObjectRepository;
            _operationRepository = operationRepository;
            _missionRepository = missionRepository;
            _userRepository = userRepository;
            _clusteringService = clusteringService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<DetectedObject>> GetDetectedObjects()
        {
            int operationId = _operationRepository.GetActiveOperationId(UserId);
            var detectedObjects = _detectedObjectRepository.Get(operationId).ToList();
            return Ok(detectedObjects);
        }

        [HttpGet("{id}", Name = "GetDetectedObjectById")]
        public ActionResult<DetectedObject> GetDetectedObjectById(int id)
        {
            var detectedObject = _detectedObjectRepository.GetById(id);
            if (detectedObject != null)
            {
                return Ok(detectedObject);
            }

            return NotFound();
        }

        [HttpGet("user", Name = "GetDetectedObjectByUserId")]
        public ActionResult<IEnumerable<DetectedObject>> GetDetectedObjectByUserId(int id)
        {
            var detectedObject = _detectedObjectRepository.GetByUserId(id);
            if (detectedObject != null)
            {
                return Ok(detectedObject);
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Координатор ПСР")]
        public ActionResult<DetectedObjectCreateDto> CreateDetectedObject(DetectedObjectCreateDto detectedObjectCreateDto)
        {
            var detectedObject = _mapper.Map<DetectedObject>(detectedObjectCreateDto);
            detectedObject.IsDesired = false;
            detectedObject.OperationId = _operationRepository.GetActiveOperationId(UserId);


            _detectedObjectRepository.Create(detectedObject);
            _detectedObjectRepository.SaveChanges();

            var detectedObjectReadDto = _mapper.Map<DetectedObject>(detectedObject);

            return CreatedAtRoute(nameof(GetDetectedObjectById), new { Id = detectedObject.Id }, detectedObjectReadDto); //Return 201
        }
        [HttpPost]
        [Authorize(Roles = "Координатор ПСР")]
        [Route("clustering")]
        public ActionResult Clusters(IEnumerable<UserDto> userDtos)
        {
            if (userDtos.Count() < 1)
            {
                return Ok();
            }
            int operationId = _operationRepository.GetActiveOperationId(UserId);
            int num_clasters = userDtos.ToList().Count();
            var users = new List<User> { };
            var objs = _detectedObjectRepository.GetVacantObjects(operationId);
            if (userDtos.Count() == 0 || objs.Count() == 0 || objs.Count() < userDtos.Count())
            {
                return Ok();
            }


            float[] scores = new float[3];
            List<PointF>[] CentroidsList = new List<PointF>[3];
            List<ClusterPoint>[] clusteredObjectsLists = new List<ClusterPoint>[3];

            int i = 0;
            foreach (var clusteredObjects in clusteredObjectsLists)
            {
                clusteredObjectsLists[i] = _clusteringService.GetClusters(num_clasters, objs, out scores[i], out CentroidsList[i++]).ToList();
            }

            int indexOfMinScore = Array.IndexOf(scores, scores.Min());

            foreach (var user in userDtos)
            {
                users.Add(_userRepository.GetById(user.Id));
            }

            double[,] distances = new double[num_clasters, num_clasters];
            i = 0;
            int j = 0;
            foreach (var centriods in CentroidsList[indexOfMinScore])
            {
                j = 0;
                foreach (var user in users)
                {

                    distances[i, j] = _clusteringService.Distance2(
                        new PointF
                        {
                            X = float.Parse(user.UserPositions.LastOrDefault(u => u.UserId == user.Id).X.Replace('.', ',')),
                            Y = float.Parse(user.UserPositions.LastOrDefault(u => u.UserId == user.Id).Y.Replace('.', ','))
                        },
                        new PointF
                        {
                            X = centriods.X,
                            Y = centriods.Y
                        }
                        );
                    j++;
                }
                i++;
            }

            Dictionary<int, (int, double)> bestDistances = new Dictionary<int, (int, double)>();

            i = 0;
            foreach (var user in userDtos)
            {
                double[] arr = new double[num_clasters];
                for (j = 0; j < num_clasters; j++)
                {
                    arr[j] = distances[i, j];
                }

                bestDistances.Add(i++, (user.Id, arr.Min())); //0 - 1 кластер, 1 - 2 кластер ...
            }
            var bestDistancesSort = bestDistances.OrderBy(r => r.Value.Item2);

            List<DetectedObject>[] detectedObjects = new List<DetectedObject>[num_clasters];
            i = 0;
            for (int q = 0; q < num_clasters; q++)
            {
                detectedObjects[i] = new List<DetectedObject> { };
                foreach (var clusterPoint in clusteredObjectsLists[indexOfMinScore].Where(p => p.ClusterNum == q))
                {
                    detectedObjects[i].Add(_detectedObjectRepository.GetById(clusterPoint.ObjectId));
                }
                i++;
            }


            //#region DEBUG  
            //DEBUG: добавляет обьекты соответствующие центроидам кластеров
            //foreach (var centroid in CentroidsList[indexOfMinScore])
            //{
            //    _detectedObjectRepository.Create(new DetectedObject
            //    {
            //        Description = "centroid",
            //        Title = "Centroid",
            //        X = centroid.X.ToString().Replace(',', '.'),
            //        Y = centroid.Y.ToString().Replace(',', '.'),
            //        OperationId = operationId,
            //        IsDesired = false
            //    });
            //}
            //#endregion



            foreach (var user in bestDistancesSort)
            {
                _missionRepository.Create(
                    new Mission
                    {
                        OperationId = operationId,
                        UserId = user.Value.Item1,
                        DetectedObjects = detectedObjects[user.Key]
                    });

            }

            _detectedObjectRepository.SaveChanges();

            return Ok();

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Координатор ПСР, Участник ПСР")]
        public ActionResult<DetectedObject> UpdateDetectedObject(int id, DetectedObjectUpdateDto detectedObjectUpdateDto)
        {
            var detectedObject = _detectedObjectRepository.GetById(id);
            if (detectedObject == null)
            {
                return NotFound();
            }

            _mapper.Map(detectedObjectUpdateDto, detectedObject);
            _detectedObjectRepository.Update(detectedObject); // Best practice
            _detectedObjectRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Координатор ПСР")]
        public ActionResult DeleteDetectedObject(int id)
        {
            var detectedObject = _detectedObjectRepository.GetById(id);
            if (detectedObject == null)
            {
                return NotFound();
            }

            _detectedObjectRepository.Delete(detectedObject);
            _detectedObjectRepository.SaveChanges();
            return NoContent();
        }
    }
}
