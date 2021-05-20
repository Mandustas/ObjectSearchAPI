using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.DTOs.DetectedObjects
{
    public class DetectedObjectUpdateDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string X { get; set; }
        [Required]
        [MaxLength(50)]
        public string Y { get; set; }
        public int? MissionId { get; set; }
    }
}
