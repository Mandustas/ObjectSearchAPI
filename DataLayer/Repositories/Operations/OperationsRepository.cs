using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Models;

namespace DataLayer.Repositories.Operations
{
    class OperationsRepository:IOperationsRepository
    {
        private readonly ObjectSearchContext _objectSearchContext;

        public OperationsRepository(ObjectSearchContext objectSearchContext)
        {
            _objectSearchContext = objectSearchContext;
        }
        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetOperations()
        {
            return _objectSearchContext.Operation.ToList();
        }

        public Operation GetOperationById()
        {
            throw new NotImplementedException();
        }

        public void CreateOperations(Operation operation)
        {
            throw new NotImplementedException();
        }

        public void DeleteOperations(Operation operation)
        {
            throw new NotImplementedException();
        }

        public void UpdateOperations(Operation operation)
        {
            throw new NotImplementedException();
        }
    }
}
