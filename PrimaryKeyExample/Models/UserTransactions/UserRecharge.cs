using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models.UserTransactions
{
    public class UserRecharge
    {
        public string Name { get; set; }
        public int MobileNumber { get; set; }
        public double Amount { get; set; }
        public int TransactionId { get; set; }
        public bool Status { get; set; }
    }
}