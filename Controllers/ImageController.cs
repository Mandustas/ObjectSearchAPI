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
        private readonly IMapper _mapper;
        public ImageController(
            IImageRepository imageRepository,
            IMapper mapper
            )
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Image>> GetImages(int? OperationId = null)
        {
            var images = _imageRepository.Get(OperationId).ToList();
            return Ok(images);
        }
    }
}
