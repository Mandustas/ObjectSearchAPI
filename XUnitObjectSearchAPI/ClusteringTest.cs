using DataLayer.Contexts;
using DataLayer.Repositories.DetectedObjects;
using Microsoft.EntityFrameworkCore;
using Moq;
using ObjectSearchAPI.Services;
using System;
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
            //Act
            var res = clusteringService.GetClusters(4, objs, out score);

            //Assert

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
