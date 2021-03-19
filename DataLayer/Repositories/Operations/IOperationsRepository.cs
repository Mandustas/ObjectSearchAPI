using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.Operations
{
    public interface IOperationsRepository
    {
        bool SaveChanges();

        IEnumerable<Models.Operation> GetOperations();
        Operation GetOperationById(int id);
        void CreateOperations(Operation operation);
        void DeleteOperations(Operation operation);
        void UpdateOperations(Operation operation);

    }
}
