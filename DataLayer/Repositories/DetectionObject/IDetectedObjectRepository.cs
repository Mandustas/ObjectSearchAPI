using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.DetectedObjects
{
    public interface IDetectedObjectRepository
    {
        bool SaveChanges();
        IEnumerable<DetectedObject> Get();
        IEnumerable<DetectedObject> GetByUserId(int id);
        DetectedObject GetById(int id);
        void Create(DetectedObject detectedObject);
        void Delete(DetectedObject detectedObject);
        void Update(DetectedObject detectedObject);

    }
}
