using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DataLayer.DTOs.ClusterPoint
{
    public class ClusterPoint
    {
        public int ObjectId { get; set; }
        public PointF Location { get; set; }
        public int ClusterNum { get; set; }

    }
}
