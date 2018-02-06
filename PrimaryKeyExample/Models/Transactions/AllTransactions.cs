using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models.Transactions
{
    public class AllTransactions
    {
        public int MobileNumber { get; set; }
        public string Operator { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfTransation { get; set; }
        public bool Status { get; set; }
    }
}