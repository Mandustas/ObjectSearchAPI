using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DetectedObject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        public bool IsDesired { get; set; }
        [Required]
        [MaxLength(50)]
        public string X { get; set; }
        [Required]
        [MaxLength(50)]
        public string Y { get; set; }
        public int? ImageId { get; set; }
        public Image Image { get; set; }
        public int? ImageMarkedUpId { get; set; }
        public Image ImageMarkedUp { get; set; }
        public int? MissionId { get; set; }
        public Mission Mission { get; set; }
        public int OperationId { get; set; }
        public Operation Operation { get; set; }
    }
}
