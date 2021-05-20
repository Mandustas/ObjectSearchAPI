﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Missions
{
    public class DetectionObjectRepository: IMissionRepository
    {
        private readonly ObjectSearchContext _objectSearchContext;

        public DetectionObjectRepository(ObjectSearchContext objectSearchContext)
        {
            _objectSearchContext = objectSearchContext;
        }
        public bool SaveChanges()
        {
            return _objectSearchContext.SaveChanges() >= 0;
        }

        public IEnumerable<Mission> Get()
        {
            var missions =  _objectSearchContext.Missions
                .Include(u => u.DetectedObjects)
                .ToList();
            return missions;
        }

        public Mission GetById(int id)
        {
            var missions = _objectSearchContext.Missions
                .Include(u => u.DetectedObjects)
                .FirstOrDefault(p => p.Id == id);
            if (missions != null)
            {

                return missions;
            }

            return null;
        }

        public void Create(Mission mission)
        {
            if (mission == null)
            {
                throw new ArgumentNullException(nameof(mission));
            }
            _objectSearchContext.Add(mission);
        }

        public void Delete(Mission mission)
        {
            if (mission == null)
            {
                throw new ArgumentNullException(nameof(mission));
            }
            _objectSearchContext.Remove(mission);
        }

        public void Update(Mission mission)
        {
            //nothing
        }
    }
}
