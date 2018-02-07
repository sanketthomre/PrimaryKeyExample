using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models.Admin_Controlls
{
    public class EditNewUser
    {
        public int NewUserId { get; set; }
        
        public string Name { get; set; }
        
        public long Aadharnum { get; set; }
        
        public long MobileNumber { get; set; }
        


    }
}