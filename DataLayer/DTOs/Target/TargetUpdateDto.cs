using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TargetUpdateDto
    {
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        public DateTime LostTime { get; set; }
        public int TargetTypeId { get; set; }
        public int TargetStatusId { get; set; }

    }
}
