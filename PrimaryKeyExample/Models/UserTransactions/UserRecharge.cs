﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models.UserTransactions
{
    public class UserRecharge
    {
        [Key]
        public int UserId { get; set; }
        public long MobileNumber { get; set; }
        public double Amount { get; set; }
        public int TransactionId { get; set; }
        public bool Status { get; set; }
    }
}