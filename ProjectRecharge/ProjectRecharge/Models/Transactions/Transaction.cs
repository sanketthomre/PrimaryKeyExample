using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectRecharge.Models.Transactions
{
    public class Transaction
    {
        [Key]
        public int TransationID { get; set; }
        public DateTime DateOfTransation { get; set; }
        public bool Status { get; set; }
        public virtual Recharge Recharge { get; set; }
        [ForeignKey("Recharge")]
        public int RechargeID { get; set; }

    }
}