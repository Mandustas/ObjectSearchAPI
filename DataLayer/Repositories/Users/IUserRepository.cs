using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;

namespace DataLayer.Repositories.Users
{
    public interface IUserRepository
    {
        bool SaveChanges();
        public IEnumerable<User> GetCoordinateUser(int userId, int operationId);
        public bool CreateUserCoordinate(double x, double y, int userId);
        IEnumerable<Models.User> Get(int? OperationId = null, int? UserRoleId = null, int? UserStatusId = null);

        public UserPosition GetLastUserPosition(int userId);
        public User GetInfoById(int userId);
        User GetById(int id);
        IEnumerable<Models.UserRole> GetRoles();
        User GetByLoginPassword(string userName, string password);
        void Create(User user);
        void Delete(User user);
        void Update(User user);

    }
}
