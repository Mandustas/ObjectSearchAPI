using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.Operations
{
    public interface IOperationsRepository
    {
        bool SaveChanges();
        IEnumerable<Operation> Get(int? coordinatorId = null);
        IEnumerable<Operation> Get(bool? isSuccess = null, int? coordinatorId = null);
        Operation GetActiveOperation(int? coordinatorId = null);
        int GetActiveOperationId(int? coordinatorId = null);
        public Operation GetByIdWithCoordinator(int id);
        Operation GetById(int id);
        Operation GetByUserId(int? userId);
        void EnterToOperationUser(OperationUser operationUser);
        void DeleteOperationUser(OperationUser operationUser);
        int GetActiveOperationIdByUserId(int? userId);
        void AddUsers(IEnumerable<User> users);
        void Create(Operation operation);
        void Delete(Operation operation);
        void Update(Operation operation);
    }
}
