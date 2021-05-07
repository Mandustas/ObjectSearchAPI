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
        public IEnumerable<DetectedObject> DetectedObjects { get; set; }



    }
}
