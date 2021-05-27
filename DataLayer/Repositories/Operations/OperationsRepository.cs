using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Operations
{
    public class OperationsRepository : IOperationsRepository
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

        public IEnumerable<Operation> Get(bool? isSuccess = null, int? coordinatorId = null)
        {
            var operations = _objectSearchContext.Operations
                .Include(u => u.Users)
                    .ThenInclude(m => m.Missions)
                        .ThenInclude(o => o.DetectedObjects)
                .Include(u => u.Users)
                    .ThenInclude(m => m.UserPositions)
                .Include(c => c.Coordinator)
                .Include(t => t.Targets)
                .ToList();

            foreach (var operation in operations) // TODO find a way to return operations without user.operations (DBO???)
            {
                operation.OperationUsers = null;
                operation.Coordinator.СontrolledOperations = null;
                foreach (var user in operation.Users)
                {
                    foreach (var mission in user.Missions)
                    {
                        foreach (var detectedObject in mission.DetectedObjects)
                        {
                            detectedObject.Mission = null;
                            detectedObject.Operation = null;
                        }

                        mission.User = null;
                        mission.User = new User();
                        mission.User.FirstName = user.FirstName;
                        mission.User.SecondName = user.SecondName;
                    }
                    foreach (var position in user.UserPositions)
                    {
                        position.User = null;
                    }
                    user.Operations = null;
                    user.OperationUsers = null;

                }
                foreach (var target in operation.Targets)
                {
                    target.Operation = null;
                }
            }

            if (isSuccess.HasValue)
            {
                operations = operations.Where(s => s.IsSuccess == isSuccess).ToList();
            }

            foreach (var operation in operations)
            {
                foreach (var user in operation.Users)
                {
                    user.UserPositions = user.UserPositions.TakeLast(1).ToList();
                }
            }
            if (coordinatorId.HasValue)
            {
                operations = operations.Where(s => s.CoordinatorId == coordinatorId).ToList();

            }

            return operations;
        }

        public Operation GetById(int id)
        {
            var operation = _objectSearchContext.Operations
                .FirstOrDefault(p => p.Id == id);
            if (operation != null)
            {
                operation.OperationUsers = null;

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
