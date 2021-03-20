using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.Operations
{
    public interface IOperationsRepository
    {
        bool SaveChanges();

        IEnumerable<Models.Operation> Get();
        Operation GetById(int id);
        void Create(Operation operation);
        void Delete(Operation operation);
        void Update(Operation operation);

    }
}
