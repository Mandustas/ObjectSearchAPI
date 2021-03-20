using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Models;

namespace DataLayer.Repositories.Operations
{
    public class OperationsRepository:IOperationsRepository
    {
        private readonly ObjectSearchContext _objectSearchContext;

        public OperationsRepository(ObjectSearchContext objectSearchContext)
        {
            _objectSearchContext = objectSearchContext;
        }
        public bool SaveChanges()
        {
            return _objectSearchContext.SaveChanges() >= 0;
        }

        public IEnumerable<Operation> Get()
        {
            return _objectSearchContext.Operations.ToList();
        }

        public Operation GetById(int id)
        {
            return _objectSearchContext.Operations.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Operation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            _objectSearchContext.Add(operation);
        }

        public void Delete(Operation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            _objectSearchContext.Remove(operation);
        }

        public void Update(Operation operation)
        {
            //nothing
        }
    }
}
