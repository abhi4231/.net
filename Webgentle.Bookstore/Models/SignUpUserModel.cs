using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage ="Please Enter Your Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [Display(Name="Email Address")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]
        [Display(Name = "Password")]
        [Compare("ComfirmPassword", ErrorMessage = "Password Does Not Match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Comfirm Your Password")]
        [Display(Name = "Comfirm Password")]
        public string ComfirmPassword { get; set; }
    }
}
