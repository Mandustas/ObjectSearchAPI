using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TargetType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        public virtual IEnumerable<Target> Targets { get; set; }

    }
}
