using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.Targets
{
    public interface ITargetRepository
    {
        bool SaveChanges();

        IEnumerable<Models.Target> Get();
        Target GetById(int id);
        void Create(Target target);
        void Delete(Target target);
        void Update(Target target);

    }
}
