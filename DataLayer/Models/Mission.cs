using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Mission
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int OperationId { get; set; }
        public Operation Operation { get; set; }
        public virtual IEnumerable<DetectedObject> DetectedObjects { get; set; }


    }
}
