using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.Bookstore.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string Location { get; set; }
        public string Designation { get; set; }
        public string PAN { get; set; }
        public string Employee_Type { get; set; }
        public string Department { get; set; }
        public string Reports_To { get; set; }
        public string Blood_Group { get; set; }
        public string ProfileImageUrl { get; set; }
        public string EmployeePdfUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
       // public DateTime Joining_Date { get; internal set; }

        internal static EmployeeContext Add(Employee newEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
