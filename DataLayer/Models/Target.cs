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
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        public string PathImage { get; set; }
        public DateTime LostTime { get; set; }

        public int OperationId { get; set; }
        public Operation Operation { get; set; }
        public int TargetStatusId { get; set; }
        public TargetStatus TargetStatus { get; set; }
        public int TargetTypeId { get; set; }
        public TargetType TargetType { get; set; }

    }
}
