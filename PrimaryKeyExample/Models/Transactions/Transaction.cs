using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models.Transactions
{
    public class Transaction
    {
        [Key]
        public int TransationID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfTransation { get; set; }
        public bool Status { get; set; }
        public virtual Recharge Recharge { get; set; }
        [ForeignKey("Recharge")]
        public int RechargeID { get; set; }
        public string ErrorMessage { get; set; }
    }
}