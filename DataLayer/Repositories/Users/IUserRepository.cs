using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.Users
{
    public interface IUserRepository
    {
        bool SaveChanges();

        IEnumerable<Models.User> Get();
        User GetById(int id);
        IEnumerable<Models.UserRole> GetRoles();
        User GetByLoginPassword(string userName, string password);
        void Create(User user);
        void Delete(User user);
        void Update(User user);
    }
}
