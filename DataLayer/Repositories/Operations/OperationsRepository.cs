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
        public int GetActiveOperationId(int? coordinatorId = null)
        {
            var operation = _objectSearchContext.Operations.Where(a => a.IsSuccess == false).FirstOrDefault(p => p.CoordinatorId == coordinatorId);
            return operation.Id;
        }
        public IEnumerable<Operation> Get(int? coordinatorId = null)
        {
            var operations = _objectSearchContext.Operations
                .Where(c => c.CoordinatorId == coordinatorId)
                .Include(u => u.Users)
                .Include(c => c.Coordinator)
                .Include(t => t.Targets)
                .ToList();
            if (operations != null)
            {
                foreach (var operation in operations) // TODO find a way to return operations without user.operations (DBO???) cycle links
                {
                    operation.OperationUsers = null;
                    operation.Coordinator.СontrolledOperations = null;
                    foreach (var user in operation.Users)
                    {
                        user.Operations = null;
                        user.OperationUsers = null;
                    }
                    foreach (var target in operation.Targets)
                    {
                        target.Operation = null;
                    }

                }
            }

            return operations;
        }

        public IEnumerable<Operation> Get(bool? isSuccess = null, int? coordinatorId = null)
        {
            var operations = _objectSearchContext.Operations.ToList();
            if (isSuccess.HasValue)
            {
                operations = operations.Where(s => s.IsSuccess == isSuccess).ToList();
            }
            return operations;
        }

        public Operation GetActiveOperation(int? coordinatorId = null)
        {
            var operation = _objectSearchContext.Operations
                .Where(c => c.CoordinatorId == coordinatorId)
                .Where(c => c.IsSuccess == false)
                .Include(u => u.Users)
                    .ThenInclude(m => m.Missions)
                        .ThenInclude(o => o.DetectedObjects)
                .Include(u => u.Users)
                    .ThenInclude(m => m.UserPositions)
                .Include(c => c.Coordinator)
                .Include(t => t.Targets)
                .FirstOrDefault();

            if (operation != null)
            {
                if (operation.Missions != null)
                {
                    foreach (var mission1 in operation.Missions)
                    {
                        mission1.Operation = null;
                        mission1.User = null;
                    }
                }
                
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
                foreach (var user in operation.Users)
                {
                    user.Missions = user.Missions.Where(o => o.OperationId == operation.Id).ToList();
                    foreach (var mission in user.Missions)
                    {
                        mission.DetectedObjects = mission.DetectedObjects.Where(o => o.OperationId == operation.Id).ToList();
                    }
                }
                foreach (var target in operation.Targets)
                {
                    target.Operation = null;
                }

                foreach (var user in operation.Users)
                {
                    user.UserPositions = user.UserPositions.TakeLast(1).ToList();
                }
            }
            return operation;
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

        public Operation GetByUserId(int? userId = null)
        {
            var operationUser = _objectSearchContext.OperationUser.FirstOrDefault(p => p.UserId == userId);
            if (operationUser == null) return null;
            var operation = _objectSearchContext.Operations.FirstOrDefault(p => p.Id == operationUser.OperationId);
            return operation;

        }
        public void EnterToOperationUser(OperationUser operationUser)
        {
            var opUser = _objectSearchContext.OperationUser.FirstOrDefault(p => p.UserId == operationUser.UserId);
            if (opUser != null) _objectSearchContext.Remove(opUser);
            _objectSearchContext.OperationUser.Add(operationUser);
        }

        public void DeleteOperationUser(OperationUser operationUser)
        {
            var opUser = _objectSearchContext.OperationUser.FirstOrDefault(p => p.UserId == operationUser.UserId);
            _objectSearchContext.Remove(opUser);
        }

        public int GetActiveOperationIdByUserId(int? userId)
        {
            var operation = _objectSearchContext.OperationUser
                .Where(p => p.UserId == userId)
                .Where(o => o.Operation.IsSuccess == false)
                .FirstOrDefault();
            //var operation = _objectSearchContext.Operations.Where(s => s.IsSuccess == false)
            //    .Include(u => u.OperationUsers)
            //    .ToList();
            return operation.OperationId;
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

        public void AddUsers(IEnumerable<User> users)
        {

        }

    }
}
