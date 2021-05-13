using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.Missions
{
    public interface IMissionRepository
    {
        bool SaveChanges();
        IEnumerable<Mission> Get();
        Mission GetById(int id);
        void Create(Mission mission);
        void Delete(Mission mission);
        void Update(Mission mission);

    }
}
