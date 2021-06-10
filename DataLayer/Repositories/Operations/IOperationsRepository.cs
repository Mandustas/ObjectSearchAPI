using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.Operations
{
    public interface IOperationsRepository
    {
        bool SaveChanges();
        IEnumerable<Operation> Get(bool? isSuccess = null, int? coordinatorId = null);
        Operation GetById(int id);
        Operation GetByUserId(int? userId);
        void EnterToOperationUser(OperationUser operationUser);
        void DeleteOperationUser(OperationUser operationUser);
        void Create(Operation operation);
        void Delete(Operation operation);
        void Update(Operation operation);
    }
}
