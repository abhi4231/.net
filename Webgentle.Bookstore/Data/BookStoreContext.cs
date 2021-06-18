using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Webgentle.Bookstore.Data
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext()
        {
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
        :base(options)
        {

        }

        public DbSet<Books> Books { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=BookStore;Integrated Security=True;");
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
