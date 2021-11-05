using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MRTOnlineTicketingSystem.Models
{
    public class User
    {
        public int Uid { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your Name")]
        public string Name { get; set; }

        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "Please select your Date of birth")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString= "{0:dd/MMM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage ="Please enter email address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        [Display(Name = "Re-enter Password")]
        [Compare("Password")]
        [Required(ErrorMessage = "Please enter your password")]
        public string RePassword { get; set; }
        public int Usertype { get; set; }
    }
}
