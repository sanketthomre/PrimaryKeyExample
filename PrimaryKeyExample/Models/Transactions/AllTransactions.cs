using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models.Transactions
{
    public class AllTransactions
    {
        //[Key]
        //public int AllTransactionID { get; set; }
        public int UserID { get; set; }
        public int MobileNumber { get; set; }
        public string Operator { get; set; }
        public double Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        public DateTime DateOfTransation { get; set; }
        public bool Status { get; set; }
    }
}