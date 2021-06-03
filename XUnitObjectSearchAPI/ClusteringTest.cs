using DataLayer.Contexts;
using DataLayer.Repositories.DetectedObjects;
using Microsoft.EntityFrameworkCore;
using Moq;
using ObjectSearchAPI.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace XUnitObjectSearchAPI
{
    public class ClusteringTest
    {
[Fact]
public void ClusteringInitTest()
{
    //Arrange
    ClusteringService clusteringService = new ClusteringService();
    var objRepo = new DetectedObjectRepository(GetContext());
    var objs = objRepo.GetVacantObjects(4);
    float score = 0;
    List<PointF> centroids = new List<PointF>();
    //Act
    var res = clusteringService.GetClusters(4, objs, out score, out centroids);
    //Assert
    Assert.NotNull(res);
}

        
        [Fact]
        public void ClusteringScoreTest()
        {
            //Arrange
            ClusteringService clusteringService = new ClusteringService();
            var objRepo = new DetectedObjectRepository(GetContext());
            var objs = objRepo.GetVacantObjects(4);
            float score = 0;
            List<PointF> centroids = new List<PointF>();
            //Act
            var res = clusteringService.GetClusters(4, objs, out score, out centroids);

            //Assert
            Assert.True(score != 0);
        }
        
        [Fact]
        public void ClusteringCentroidsTest()
        {
            //Arrange
            ClusteringService clusteringService = new ClusteringService();
            var objRepo = new DetectedObjectRepository(GetContext());
            var objs = objRepo.GetVacantObjects(4);
            float score = 0;
            List<PointF> centroids = new List<PointF>();
            //Act
            var res = clusteringService.GetClusters(4, objs, out score, out centroids);

            //Assert
            Assert.NotNull(centroids);
        }
        
        
        [Fact]
        public void ClusteringNullClustersTest()
        {
            //Arrange
            ClusteringService clusteringService = new ClusteringService();
            var objRepo = new DetectedObjectRepository(GetContext());
            var objs = objRepo.GetVacantObjects(4);
            float score = 0;
            List<PointF> centroids = new List<PointF>();
            //Act
            var res = clusteringService.GetClusters(0, objs, out score, out centroids);

            //Assert
            Assert.Null(res);
        }
        [Fact]
        public void ClusteringNullObjectsTest()
        {
            //Arrange
            ClusteringService clusteringService = new ClusteringService();
            var objRepo = new DetectedObjectRepository(GetContext());
            IEnumerable<DataLayer.Models.DetectedObject> objs = new List<DataLayer.Models.DetectedObject>();
            float score = 0;
            List<PointF> centroids = new List<PointF>();
            //Act
            var res = clusteringService.GetClusters(4, objs, out score, out centroids);

            //Assert
            Assert.Null(res);
        }



        private ObjectSearchContext GetContext()
        {
            var contextOptions = new DbContextOptionsBuilder<ObjectSearchContext>()
                .UseSqlServer("Server=.\\SQLEXPRESS2017; Initial Catalog=ObjectSearchDB; Trusted_Connection=true;")
                .Options;
            var context = new ObjectSearchContext(contextOptions);
            // create and configure context
            // see: https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/
            return context;
        }

    }
}
