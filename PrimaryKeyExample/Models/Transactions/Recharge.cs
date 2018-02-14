using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models.Transactions
{
    public class Recharge
    {
        [Key]
        public int RechargeID { get; set; }
        [Required(ErrorMessage ="Can't Imagine Recharge without a number")]
        public string MobileNumber { get; set; }
        public string Operator { get; set; }
        [Required(ErrorMessage ="Please Provide with Amount")]
        public double Amount { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
        public int UserID { get; set; }
    }
}