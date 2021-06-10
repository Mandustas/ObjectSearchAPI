using DataLayer.DTOs.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.DTOs.DetectedObjects
{
    public class DetectedObjectWithImagesCreateDto
    {
        public ImageObjectCreateDto Image { get; set; } = null!;
        public ImageObjectCreateDto ImageMarkedUp { get; set; } = null!;
        public IEnumerable<DetectedObjectLightCreateDto> DetectedObjects { get; set; }
    }
}
