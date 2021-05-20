using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime TimeCreate { get; set; }
        public int QtyFindObject { get; set; }
        public int QtyVerifiedObject { get; set; }
        public int CycleId { get; set; }
        public Cycle Cycle { get; set; }
        public virtual IEnumerable<DetectedObject> DetectedObjects { get; set; }
        public virtual IEnumerable<DetectedObject> DetectedObjectsMarkUp { get; set; }



    }
}
