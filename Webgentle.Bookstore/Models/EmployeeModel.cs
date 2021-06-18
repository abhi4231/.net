using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Webgentle.Bookstore.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string Last_Name { get; set; }
       
        public string Gender { get; set; }
        public string Email { get; set; }
      
        public String DOB { get; set; }
        public string Location { get; set; }
        public string Designation { get; set; }
        public string PAN { get; set; }
        public string Employee_Type { get; set; }
        public string Department { get; set; }
        public string Reports_To { get; set; }
        public string Blood_Group { get; set; }
       // [DataType(DataType.DateTime)]
       //public DateTime Joining_Date{ get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [Display(Name ="Choose the profile image")]
       // [Required]
        public IFormFile ProfileImage { get; set; }
        public string ProfileImageUrl { get; set; }


        [Display(Name = "Choose the Documents")]
        // [Required]
        public IFormFile EmployeeDoc { get; set; }  
        public string EmployeePdfUrl { get; set; }
    }
}
