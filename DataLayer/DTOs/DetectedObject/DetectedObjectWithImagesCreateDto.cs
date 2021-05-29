using DataLayer.DTOs.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.DTOs.DetectedObjects
{
    public class DetectedObjectWithImagesCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string X { get; set; }
        [Required]
        [MaxLength(50)]
        public string Y { get; set; }
        public int TypeId { get; set; }
        public ImageObjectCreateDto Image { get; set; } = null!;
        public ImageObjectCreateDto ImageMarkedUp { get; set; } = null!;
    }
}
