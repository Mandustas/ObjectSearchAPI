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

        public IEnumerable<DetectedObject> Get(int? operationId = null)
        {
            var detectedObjects = _objectSearchContext.DetectedObjects
                .Include(i => i.Image)
                .ToList();
            foreach (var detectedObject in detectedObjects)
            {
                if (detectedObject.Image!=null)
                {
                    detectedObject.Image.DetectedObjects = null;
                    detectedObject.Image.DetectedObjectsMarkUp = null;
                }
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
