using AutoMapper;
using DataLayer.DTOs.DetectedObjects;
using DataLayer.Models;
using DataLayer.Repositories.DetectedObjects;
using DataLayer.Repositories.Missions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetectedObjectController : ControllerBase
    {
        private readonly IDetectedObjectRepository _detectedObjectRepository;
        private readonly IMapper _mapper;
        public DetectedObjectController(
            IDetectedObjectRepository detectedObjectRepository,
            IMapper mapper
            )
        {
            _detectedObjectRepository = detectedObjectRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<DetectedObject>> GetDetectedObjects(int? operationId = null)
        {
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
        public ActionResult<DetectedObjectCreateDto> CreateDetectedObject(DetectedObjectCreateDto detectedObjectCreateDto)
        {
            var detectedObject = _mapper.Map<DetectedObject>(detectedObjectCreateDto);
            detectedObject.IsDesired = false;


            _detectedObjectRepository.Create(detectedObject);
            _detectedObjectRepository.SaveChanges();

            var detectedObjectReadDto = _mapper.Map<DetectedObject>(detectedObject);

            return CreatedAtRoute(nameof(GetDetectedObjectById), new { Id = detectedObject.Id }, detectedObjectReadDto); //Return 201
        }

        [HttpPut("{id}")]
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
