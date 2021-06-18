using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Webgentle.Bookstore.Data;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Repository
{
    public class EmployeeRepository
    {
         private readonly EmployeeContext _context = null;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewEmployee(EmployeeModel model)
        {
            var newEmployee = new Employee()
            {
                Id = model.Id, 
                CreatedOn = DateTime.UtcNow,
                First_Name = model.First_Name,
                UpdatedOn = DateTime.UtcNow,
                Last_Name = model.Last_Name,
                Gender = model.Gender,
                Email=model.Email,
                DOB=model.DOB,
                Location=model.Location,
                Designation=model.Designation,
                PAN=model.PAN,
                Employee_Type=model.Employee_Type,
                Department=model.Department,
                Reports_To=model.Reports_To,
                Blood_Group=model.Blood_Group,
                EmployeePdfUrl=model.EmployeePdfUrl,
                ProfileImageUrl=model.ProfileImageUrl
              //  Joining_Date=model.Joining_Date
            };

           await _context.Employee.AddAsync(newEmployee);
           await _context.SaveChangesAsync();

            return newEmployee.Id;
        }

        private EmployeeContext SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task <List<EmployeeModel>> GetAllEmployees()
        {
            return await _context.Employee
                .Select(employee => new EmployeeModel()
                //var employees = new List<EmployeeModel>();
                // var allemployees = await _context.Employee.ToListAsync();
                // if (allemployees?.Any() == true)
                // {
                // foreach (var employee in allemployees)
                // {
                //  employees.Add(new EmployeeModel()
                {
                       Id=employee.Id,
                        First_Name= employee.First_Name,
                        Last_Name=employee.Last_Name,
                        Gender=employee.Gender,
                        Email=employee.Email,
                        DOB=employee.DOB,
                        Location=employee.Location,
                        Designation=employee.Location,
                        PAN=employee.PAN,
                        Employee_Type=employee.Employee_Type,
                        Department=employee.Department,
                        Reports_To=employee.Reports_To,
                        Blood_Group=employee.Blood_Group,
                       
                    }).ToListAsync();
                }
           

        public async Task<EmployeeModel>  GetEmployeeById(int id)
        {
            return await _context.Employee.Where(x => x.Id == id)
                .Select(employee => new EmployeeModel()

                //   var employee = await _context.Employee.FindAsync(id);
                // if (employee != null)

                //   var employeeDetails = new EmployeeModel()
                {
                    Id = employee.Id,
                    First_Name = employee.First_Name,
                    Last_Name = employee.Last_Name,
                    Gender = employee.Gender,
                    Email = employee.Email,
                    DOB = employee.DOB,
                    Location = employee.Location,
                    Designation = employee.Location,
                    PAN = employee.PAN,
                    Employee_Type = employee.Employee_Type,
                    Department = employee.Department,
                    Reports_To = employee.Reports_To,
                    Blood_Group = employee.Blood_Group,
                    ProfileImageUrl=employee.ProfileImageUrl,

                    EmployeePdfUrl=employee.EmployeePdfUrl
                }).FirstOrDefaultAsync();
                
             
            

        }

        public List<EmployeeModel> SearchEmployee(int Id, string PAN)
        {
            return DataSource().Where(x => x.Id==(Id) || x.PAN.Contains(PAN) ).ToList();
        }

        private List<EmployeeModel> DataSource()
        {
            return new List<EmployeeModel>()
            {
                new EmployeeModel() {Id = 1, First_Name = "Abhijit", Last_Name = "Naikwadi",Gender="Male",Email = "abhijitrnaikwadi@gmail.com",DOB = "7/8/1998",Designation = "Manager"}
            };
        }
    }
}
