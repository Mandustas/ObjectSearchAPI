using AutoMapper;
using DataLayer.DTOs.DetectedObjects;
using DataLayer.Models;
using DataLayer.Repositories.DetectedObjects;
using DataLayer.Repositories.Images;
using DataLayer.Repositories.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObjectSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        private readonly IImageRepository _imageRepository;
        private readonly IDetectedObjectRepository _detectedObjectRepository;
        private readonly IOperationsRepository _operationRepository;

        public ImageController(
            IImageRepository imageRepository,
            IDetectedObjectRepository detectedObjectRepository,
            IOperationsRepository operationRepository,

            IMapper mapper
            )
        {
            _imageRepository = imageRepository;
            _operationRepository = operationRepository;
            _detectedObjectRepository = detectedObjectRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Image>> GetImages()
        {
            int OperationId = _operationRepository.GetActiveOperationId(UserId);

            var images = _imageRepository.Get(OperationId).ToList();
            return Ok(images);
        }


        [HttpPost]
        public ActionResult<IEnumerable<DetectedObjectWithImagesCreateDto>> CreateImagesAndObjects(IEnumerable<DetectedObjectWithImagesCreateDto> detectedObjectCreateDtos)
        {
            int OperationId = _operationRepository.GetActiveOperationId(UserId);


            Cycle cycle = new Cycle
            {
                Title = "Облет",
                Description = "Автоматически созданный облет",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                OperationId = OperationId, //TODO: Заменить Id операции
            };

            foreach (var img in detectedObjectCreateDtos.ToList())
            {
                List<DetectedObject> detectedObjects = new List<DetectedObject>();
                foreach (var obj in img.DetectedObjects)
                {
                    detectedObjects.Add(new DetectedObject
                    {
                        Description = obj.TypeId == 0 ? "Человек" : "Автомобиль",
                        Title = "Найденный объект",
                        X = obj.X,
                        Y = obj.Y,
                        IsDesired = false,
                        OperationId = OperationId,
                    });
                }
                _imageRepository.Create(new Image
                {
                    Path = img.Image.Path,
                    Cycle = cycle,
                    QtyFindObject = 1,
                    QtyVerifiedObject = 1,
                    TimeCreate = DateTime.Now,
                    DetectedObjects = detectedObjects
                });
                _imageRepository.Create(new Image
                {
                    Path = img.ImageMarkedUp.Path,
                    Cycle = cycle,
                    QtyFindObject = 1,
                    QtyVerifiedObject = 1,
                    TimeCreate = DateTime.Now,
                    DetectedObjectsMarkUp = detectedObjects
                });

                //_detectedObjectRepository.Create(new DetectedObject
                //{
                //    Description = obj.TypeId == 0 ? "Человек" : "Автомобиль",
                //    Title = "Найденный объект",
                //    X = obj.X,
                //    Y = obj.Y,
                //    IsDesired = false,
                //    OperationId = OperationId,

                //    Image = new Image
                //    {
                //        Path = obj.Image.Path,
                //        Cycle = cycle,
                //        QtyFindObject = 1,
                //        QtyVerifiedObject = 1,
                //        TimeCreate = DateTime.Now

                //    },
                //    ImageMarkedUp = new Image
                //    {
                //        Path = obj.ImageMarkedUp.Path,
                //        Cycle = cycle,
                //        QtyFindObject = 1,
                //        QtyVerifiedObject = 1,
                //        TimeCreate = DateTime.Now
                //    },
                //});
            }
            _detectedObjectRepository.SaveChanges();
            return Ok();
        }
    }
}
