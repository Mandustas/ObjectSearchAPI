using DataLayer.DTOs.ClusterPoint;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectSearchAPI.Services
{
    public interface IClusteringService
    {
        double Distance(PointF point1, PointF point2);
        double Distance2(PointF point1, PointF point2);
        public IEnumerable<ClusterPoint> GetClusters(int num_clusters, IEnumerable<DetectedObject> detectedObjects, out float score, out List<PointF> Centroids);

    }
}
