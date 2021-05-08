using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Operation> Get(bool? isSuccess=null)
        {
            var operations =  _objectSearchContext.Operations
                .Include(u => u.Users)
                .Include(t => t.Targets)
                .ToList();

            foreach (var operation in operations) // TODO find a way to return operations without user.operations (DBO???)
            {
                foreach (var user in operation.Users)
                {
                    user.Operation = null;
                }
            }

            if (isSuccess.HasValue)
            {
                operations = operations.Where(s => s.IsSuccess == isSuccess).ToList();
            }

            return operations;
        }

        public Operation GetById(int id)
        {
            var operation = _objectSearchContext.Operations
                .Include(u => u.Users)
                .Include(t => t.Targets)
                .FirstOrDefault(p => p.Id == id);
            if (operation != null)
            {
                foreach (var user in operation.Users)
                {
                    user.Operation = null;
                }

                return operation;
            }

            return null;
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
