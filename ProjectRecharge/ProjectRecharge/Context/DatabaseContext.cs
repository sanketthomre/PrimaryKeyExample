using ProjectRecharge.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectRecharge.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Recharge> Recharge { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}