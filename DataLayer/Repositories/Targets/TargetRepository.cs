using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Models;

namespace DataLayer.Repositories.Targets
{
    public class TargetRepository : ITargetRepository
    {
        private readonly ObjectSearchContext _objectSearchContext;

        public TargetRepository(ObjectSearchContext objectSearchContext)
        {
            _objectSearchContext = objectSearchContext;
        }
        public bool SaveChanges()
        {
            return (_objectSearchContext.SaveChanges() >= 0);
        }

        public IEnumerable<Target> Get()
        {
            return _objectSearchContext.Targets.ToList();
        }

        public IEnumerable<Target> GetByUserId(int id)
        {
            var operationUser = _objectSearchContext.OperationUser.FirstOrDefault(p => p.UserId == id);
            if (operationUser == null) return null;
            return _objectSearchContext.Targets.Where(p => p.OperationId == operationUser.OperationId).ToList();
        }

        public Target GetById(int id)
        {
            return _objectSearchContext.Targets.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Target target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            _objectSearchContext.Add(target);
        }

        public void Delete(Target target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            _objectSearchContext.Remove(target);
        }

        public void Update(Target target)
        {
            //nothing
        }
    }
}
