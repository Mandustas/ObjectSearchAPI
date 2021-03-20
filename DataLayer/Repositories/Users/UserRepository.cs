﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Models;

namespace DataLayer.Repositories.Users
{
    class UserRepository:IUserRepository
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

        public IEnumerable<User> Get()
        {
            return _objectSearchContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _objectSearchContext.Users.FirstOrDefault(p => p.Id == id);

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
