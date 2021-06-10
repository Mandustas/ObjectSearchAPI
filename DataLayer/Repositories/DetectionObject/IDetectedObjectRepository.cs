using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.DetectedObjects
{
    public interface IDetectedObjectRepository
    {
        bool SaveChanges();
        IEnumerable<DetectedObject> Get(int? operationId = null, int? missionId = null, bool? isDesired = null);
        IEnumerable<DetectedObject> GetVacantObjects(int? operationId = null);
        IEnumerable<DetectedObject> GetByUserId(int id);
        IEnumerable<DetectedObject> GetByMissionId(int id);
        DetectedObject GetById(int id);
        void Create(DetectedObject detectedObject);
        void Delete(DetectedObject detectedObject);
        void Update(DetectedObject detectedObject);

    }
}
