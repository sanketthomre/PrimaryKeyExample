using PrimaryKeyExample.Models;
using PrimaryKeyExample.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<NewUserEdit> NewUSers { get; set; }
        public DbSet<Recharge> Recharge { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}