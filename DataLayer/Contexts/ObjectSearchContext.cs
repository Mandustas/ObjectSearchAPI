using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Contexts
{
    public class ObjectSearchContext : DbContext
    {
        public ObjectSearchContext(DbContextOptions options) : base(options) { }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
