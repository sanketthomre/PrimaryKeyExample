using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models.Transactions
{
    public class TransactionID
    {
        [Key]
        public int ID { get; set; }
        public long TransID { get; set; }
        public int RechargeId { get; set; }
    }
}