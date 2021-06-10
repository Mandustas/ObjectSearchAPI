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

        public IEnumerable<Operation> Get(bool? isSuccess = null, int? coordinatorId = null)
        {
            var operations = _objectSearchContext.Operations

                .Include(u => u.Users)
                    .ThenInclude(m => m.Missions)
                        .ThenInclude(o => o.DetectedObjects)
                .Include(u => u.Users)
                    .ThenInclude(m => m.UserPositions)
                .Include(c => c.Coordinator)
                .Include(t => t.Targets)
                .ToList();

            foreach (var operation in operations) // TODO find a way to return operations without user.operations (DBO???)
            {
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
                foreach (var target in operation.Targets)
                {
                    target.Operation = null;
                }
            }

            if (isSuccess.HasValue)
            {
                operations = operations.Where(s => s.IsSuccess == isSuccess).ToList();
            }

            foreach (var operation in operations)
            {
                foreach (var user in operation.Users)
                {
                    user.UserPositions = user.UserPositions.TakeLast(1).ToList();
                }
            }
            if (coordinatorId.HasValue)
            {
                operations = operations.Where(s => s.CoordinatorId == coordinatorId).ToList();

            }

            return operations;
        }

        public User GetById(int id)
        {
            var user = _objectSearchContext.Users
                .Include(p => p.UserPositions)
                .FirstOrDefault(q => q.Id == id);

            if (user != null)
            {
                //foreach (var position in user.UserPositions)
                //{
                //    position.User = null;
                //}
                return user;
            }
            return null;

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
