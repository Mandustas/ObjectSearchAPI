using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Images
{
    public class ImageRepository : IImageRepository
    {
        private readonly ObjectSearchContext _objectSearchContext;

        public ImageRepository(ObjectSearchContext objectSearchContext)
        {
            _objectSearchContext = objectSearchContext;
        }
        public bool SaveChanges()
        {
            return _objectSearchContext.SaveChanges() >= 0;
        }

        public IEnumerable<Cycle> Get(int? OperationId = null)
        {
            var cycles = _objectSearchContext.Cycles.Include(u => u.Images).Where(s => s.OperationId == OperationId)
                .ToList();
            foreach (var cycle in cycles)
            {
                cycle.Operation = null;
                foreach (var image in cycle.Images)
                {
                    image.Cycle = null;
                    image.DetectedObjects = null;

                }

            }
            return cycles;
        }

        public Image GetById(int id)
        {
            var images = _objectSearchContext.Images
                .FirstOrDefault(p => p.Id == id);
            if (images != null)
            {
                return images;
            }

            return null;
        }

        public void Create(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }
            _objectSearchContext.Add(image);
        }

        public void Delete(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }
            _objectSearchContext.Remove(image);
        }

        public void Update(Image image)
        {
            //nothing
        }
    }
}
