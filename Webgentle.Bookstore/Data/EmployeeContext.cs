using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webgentle.BookStore.Models;

namespace Webgentle.Bookstore.Data
{
    public class EmployeeContext : IdentityDbContext<ApplicationUser>
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlServer("server=.;Database=BookStore;Integrated Security=True;");
             base.OnConfiguring(optionsBuilder);
         }*/
    }
}
