using PrimaryKeyExample.Models;
using PrimaryKeyExample.Models.Transactions;
using PrimaryKeyExample.Models.UserTransactions;
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
        //public DbSet<UserRecharge> UserRecharge { get; set; }
        public DbSet<GuestLogin> Guests { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<NewUser>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserRecharge> UserRecharges { get; set; }
    }
}