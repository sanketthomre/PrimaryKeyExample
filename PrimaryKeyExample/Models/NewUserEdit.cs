﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimaryKeyExample.Models
{
    public class NewUserEdit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewUserId { get; set; }

        public int UserId { get; set; }

        [Index(IsUnique = true)]
        [NotMapped, MinLength(6), MaxLength(50)]
        [Remote("CheckExistingUserName", "NewUserRegister", ErrorMessage = "UserName already exists!")]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Password name is required")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Aadhar number is required")]
        public long Aadharnum { get; set; }

        //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        [RegularExpression("^[0 - 9]{10}$")]
        [Required(ErrorMessage = "Contact number is required")]
        public string MobileNumber { get; set; }
        // public List<SelectListItem> State { get; set; }


    }
    public class Login
    {
        [Required(ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is Required")]
        public string Password { get; set; }
    }
}