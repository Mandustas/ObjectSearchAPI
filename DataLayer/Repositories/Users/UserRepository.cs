using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ObjectSearchContext _objectSearchContext;

        public UserRepository(ObjectSearchContext objectSearchContext)
        {
            _objectSearchContext = objectSearchContext;
        }
        public bool SaveChanges()
        {
            return (_objectSearchContext.SaveChanges() >= 0);
        }

        public IEnumerable<User> Get(int? OperationId = null, int? UserRoleId = null, int? UserStatusId = null)
        {
            IEnumerable<User> users = new List<User> { };
            if (OperationId != null)
            {
                var operation = _objectSearchContext.Operations.Where(i => i.Id == OperationId)
               .Include(u => u.Users)
               .FirstOrDefault();
                users = operation.Users;
            }
            else
            {
                users = _objectSearchContext.Users
                    .ToList();
            }

            if (UserRoleId != null)
            {
                users = users.Where(r => r.UserRoleId == UserRoleId).ToList();
            }
            if (UserStatusId != null)
            {
                users = users.Where(r => r.UserStatusId == UserStatusId).ToList();
            }

            return users;
        }

        public User GetById(int id)
        {
            var user = _objectSearchContext.Users
                .Include(p => p.UserPositions)
                .FirstOrDefault(p => p.Id == id);

            if (user != null)
            {
                foreach (var position in user.UserPositions)
                {
                    position.User = null;
                }
            }
            return user;
        }
        public IEnumerable<UserRole> GetRoles()
        {
            return _objectSearchContext.UserRoles.ToList();

        }
        public User GetByLoginPassword(string userName, string password)
        {
            var user = _objectSearchContext.Users
                .Include(r => r.UserRole)
                .FirstOrDefault(p => p.UserName == userName && p.PasswordHash == password);
            if (user != null)
            {
                user.UserRole.Users = null;

            }
            return user;
        }

        public void Create(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _objectSearchContext.Add(user);
        }

        public void Delete(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _objectSearchContext.Remove(user);
        }

        public void Update(User user)
        {
            //nothing
        }


    }
}
