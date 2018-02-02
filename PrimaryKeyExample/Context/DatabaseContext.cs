using PrimaryKeyExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<NewUser> NewUSers { get; set; }

        //public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}