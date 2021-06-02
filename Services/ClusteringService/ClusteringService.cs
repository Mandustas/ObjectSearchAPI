using DataLayer.DTOs.ClusterPoint;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ObjectSearchAPI.Services
{
    public class ClusteringService : IClusteringService
    {
        public IEnumerable<ClusterPoint> GetClusters(int num_clusters, IEnumerable<DetectedObject> detectedObjects, out float score, out List<PointF> Centroids)
        {
            var Points = new List<ClusterPoint>();
            Centroids = new List<PointF>();

            foreach (var detectedObject in detectedObjects)
            {
                Points.Add(new ClusterPoint
                {
                    ObjectId = detectedObject.Id,
                    Location = new PointF
                    {
                        X = float.Parse((detectedObject.X).Replace('.', ',')),
                        Y = float.Parse((detectedObject.Y).Replace('.', ','))
                    },
                    ClusterNum = 0
                });
            }
            Points.Randomize();
            for (int i = 0; i < num_clusters; i++)
                Centroids.Add(Points[i].Location);
            foreach (var point_data in Points)
                point_data.ClusterNum = 0;
            bool centroids_changed = true;
            int iter = 0;
            while (centroids_changed)
            {
                centroids_changed = false;
                PointF[] new_centers = new PointF[num_clusters];
                int[] num_points = new int[num_clusters];
                foreach (var point in Points)
                {
                    double best_dist =
                        Distance(point.Location, Centroids[0]);
                    int best_cluster = 0;
                    for (int i = 1; i < num_clusters; i++)
                    {
                        double test_dist =
                            Distance(point.Location, Centroids[i]);
                        if (test_dist < best_dist)
                        {
                            best_dist = test_dist;
                            best_cluster = i;
                        }
                    }
                    point.ClusterNum = best_cluster;
                    new_centers[best_cluster].X += point.Location.X;
                    new_centers[best_cluster].Y += point.Location.Y;
                    num_points[best_cluster]++;
                }

                // Calculate the new centroids.
                List<PointF> new_centroids = new List<PointF>();
                for (int i = 0; i < num_clusters; i++)
                {
                    new_centroids.Add(new PointF(
                        new_centers[i].X / num_points[i],
                        new_centers[i].Y / num_points[i]));
                }

                // See if the centroids have moved.
                for (int i = 0; i < num_clusters; i++)
                {
                    const float min_change = 0.05f;
                    if ((Math.Abs(Centroids[i].X - new_centroids[i].X) > min_change) ||
                        (Math.Abs(Centroids[i].Y - new_centroids[i].Y) > min_change))
                    {
                        centroids_changed = true;
                        break;
                    }
                }
                iter++;
                if (!centroids_changed)
                {
                    break;
                }

                // Update the centroids.
                Centroids = new_centroids;
            }
            score = Score(Points, Centroids);
            return Points;
        }

        public double Distance2(PointF point1, PointF point2)
        {
            float dx = point1.X - point2.X;
            float dy = point1.Y - point2.Y;
            return dx * dx + dy * dy;
        }

        public double Distance(PointF point1, PointF point2)
        {
            float dx = point1.X - point2.X;
            float dy = point1.Y - point2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private float Score(List<ClusterPoint> Points, List<PointF> Centroids)
        {
            float score = 0;
            foreach (var point in Points)
            {
                float dx = Centroids[point.ClusterNum].X - point.Location.X;
                float dy = Centroids[point.ClusterNum].Y - point.Location.Y;
                score += dx * dx + dy * dy;
            }
            return score;
        }
    }
}
