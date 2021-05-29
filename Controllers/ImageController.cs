using AutoMapper;
using DataLayer.DTOs.DetectedObjects;
using DataLayer.Models;
using DataLayer.Repositories.DetectedObjects;
using DataLayer.Repositories.Images;
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
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IDetectedObjectRepository _detectedObjectRepository;

        private readonly IMapper _mapper;
        public ImageController(
            IImageRepository imageRepository,
            IDetectedObjectRepository detectedObjectRepository,

            IMapper mapper
            )
        {
            _imageRepository = imageRepository;
            _detectedObjectRepository = detectedObjectRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Image>> GetImages(int? OperationId = null)
        {
            var images = _imageRepository.Get(OperationId).ToList();
            return Ok(images);
        }


        [HttpPost]
        public ActionResult<IEnumerable<DetectedObjectWithImagesCreateDto>> CreateImagesAndObjects(IEnumerable<DetectedObjectWithImagesCreateDto> detectedObjectCreateDtos)
        {
            List<DetectedObject> detectedObjects = new List<DetectedObject>();
            Cycle cycle = new Cycle
            {
                Title = "Облет",
                Description = "Автоматически созданный облет",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                OperationId = 1, //TODO: Заменить Id операции

            };

            foreach (var obj in detectedObjectCreateDtos.ToList())
            {

                //detectedObjects.Add(
                    
                //);
                _detectedObjectRepository.Create(new DetectedObject
                {
                    Description = "",
                    Title = "",
                    X = obj.X,
                    Y = obj.Y,
                    IsDesired = false,
                    OperationId = 1, //TODO: Заменить Id операции

                    Image = new Image
                    {
                        Path = obj.Image.Path,
                        Cycle = cycle,
                        QtyFindObject = 1,
                        QtyVerifiedObject = 1,
                        TimeCreate = DateTime.Now

                    },
                    ImageMarkedUp = new Image
                    {
                        Path = obj.ImageMarkedUp.Path,
                        Cycle = cycle,
                        QtyFindObject = 1,
                        QtyVerifiedObject = 1,
                        TimeCreate = DateTime.Now
                    },
                });
            }
            _detectedObjectRepository.SaveChanges();
            return null;
        }
    }
}
