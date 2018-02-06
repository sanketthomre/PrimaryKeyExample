﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimaryKeyExample.Models.Admin_Controlls
{
    public class NewUsersEdit
    {
        public int NewUserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Aadhar number is required")]
        public long Aadharnum { get; set; }

        
        [Required(ErrorMessage = "Contact number is required")]
        public long MobileNumber { get; set; }
        


    }
}