using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimaryKeyExample.Models.Transactions
{
    public class Recharge
    {
        [Key]
        public int RechargeId { get; set; }
        public int MobileNumber { get; set; }
        public List<SelectList> Sim_Type { get; set; }
        public double Amount { get; set; }
    }
    public class TransactionID : Recharge
    {
        public long TransID { get; set; }
    }
}