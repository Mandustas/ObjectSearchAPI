using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.DetectedObjects
{
    public class DetectedObjectRepository : IDetectedObjectRepository
    {
        private readonly ObjectSearchContext _objectSearchContext;

        public DetectedObjectRepository(ObjectSearchContext objectSearchContext)
        {
            _objectSearchContext = objectSearchContext;
        }
        public bool SaveChanges()
        {
            return _objectSearchContext.SaveChanges() >= 0;
        }

        public IEnumerable<DetectedObject> Get(int? operationId = null, int? missionId = null, bool? isDesired = null, bool? isFree = null)
        {
            
            var detectedObjects = _objectSearchContext.DetectedObjects
                .Include(i => i.ImageMarkedUp)

                .ToList();
            foreach (var detectedObject in detectedObjects)
            {
                //if (detectedObject.Image!=null)
                //{
                //    detectedObject.Image.DetectedObjects = null;
                //    detectedObject.Image.DetectedObjectsMarkUp = null;
                //}
                if (detectedObject.ImageMarkedUp != null)
                {
                    detectedObject.ImageMarkedUp.DetectedObjects = null;
                    detectedObject.ImageMarkedUp.DetectedObjectsMarkUp = null;
                }
                detectedObject.Operation = null;
            }
            if (operationId.HasValue)
            {
                detectedObjects = detectedObjects.Where(s => s.OperationId == operationId).ToList();
            }
            if (isFree.HasValue && isFree == true)
            {
                detectedObjects = detectedObjects.Where(s => s.MissionId == null).ToList();
            } 
            if (missionId.HasValue && !isFree.HasValue)
            {
                detectedObjects = detectedObjects.Where(s => s.MissionId == missionId).ToList();
            } 
            if (isDesired.HasValue)
            {
                detectedObjects = detectedObjects.Where(s => s.IsDesired == isDesired).ToList();
            }
            return detectedObjects;
        }

        public IEnumerable<DetectedObject> GetVacantObjects(int? operationId = null)
        {

            var detectedObjects = _objectSearchContext.DetectedObjects
                .Where(d => d.IsDesired == false)
                .Where(o => o.OperationId == operationId)
                .Where(m => m.MissionId == null)
                .ToList();
            
            
            return detectedObjects;
        }

        public DetectedObject GetById(int id)
        {
            var detectedObject = _objectSearchContext.DetectedObjects
                .FirstOrDefault(p => p.Id == id);
            if (detectedObject != null)
            {

                return detectedObject;
            }

            return null;
        }

        public IEnumerable<DetectedObject> GetByUserId(int id)
        {
            var detectedObject = _objectSearchContext.DetectedObjects
                .Include(m => m.Mission)
                .Where(p => p.Mission.UserId == id)
                .ToList();
            foreach(var obj in detectedObject)
            {
                obj.Mission.DetectedObjects = null;
            }
            return detectedObject;

        }

        public IEnumerable<DetectedObject> GetByMissionId(int id)
        {
            var detectedObject = _objectSearchContext.DetectedObjects
                .Where(d => d.MissionId == id)
                .ToList();
            return detectedObject;
         
        }

        public void Create(DetectedObject detectedObject)
        {
            if (detectedObject == null)
            {
                throw new ArgumentNullException(nameof(detectedObject));
            }
            _objectSearchContext.Add(detectedObject);
        }

        public void Delete(DetectedObject detectedObject)
        {
            if (detectedObject == null)
            {
                throw new ArgumentNullException(nameof(detectedObject));
            }
            _objectSearchContext.Remove(detectedObject);
        }

        public void Update(DetectedObject detectedObjects)
        {
            //nothing
        }
    }
}
