using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectRecharge.Models.Users
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewUserId { get; set; }

        public int UserId { get; set; }

        [Index(IsUnique = true)]
        [NotMapped, MinLength(6), MaxLength(50)]
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
        [Required(ErrorMessage = "Contact number is required")]
        public long MobileNumber { get; set; }
        public List<SelectList> State { get; set; }
    }
}