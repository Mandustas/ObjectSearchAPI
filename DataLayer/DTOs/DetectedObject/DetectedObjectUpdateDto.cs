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
        [Required]
        public string Description { get; set; }
        public int? MissionId { get; set; }
        public bool IsDesired { get; set; }
    }
}
