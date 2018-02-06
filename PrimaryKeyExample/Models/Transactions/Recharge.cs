using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models.Transactions
{
    public class Recharge
    {
        [Key]
        public int RechargeID { get; set; }
        public int MobileNumber { get; set; }
        public string Operator { get; set; }
        public double Amount { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}