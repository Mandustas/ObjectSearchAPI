using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class MissionCreateDto
    {
        [Required]
        public int UserId { get; set; }


    }
}
