using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Target
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        public DateTime LostTime { get; set; }

    }
}
