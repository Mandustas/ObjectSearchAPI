using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class UserPosition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string X { get; set; }
        [Required]
        [MaxLength(50)]
        public string Y { get; set; }

    }
}
