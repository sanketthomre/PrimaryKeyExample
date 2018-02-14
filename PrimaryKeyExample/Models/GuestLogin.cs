using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models
{
    public class GuestLogin
    {
        [Key]
        public int GuestLoginID { get; set; }
        public string EmailId { get; set; }
        public long MobileNumber { get; set; }
    }
}