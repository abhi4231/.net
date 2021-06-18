using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Webgentle.Bookstore.Data;
using Webgentle.Bookstore.Respository;
using Webgentle.Bookstore.Repository;
using Microsoft.AspNetCore.Identity;
using Webgentle.BookStore.Models;

namespace Webgentle.Bookstore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EmployeeContext>();

            services.Configure<IdentityOptions>(Options =>
            {
                Options.Password.RequiredLength = 5;
                });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/login";
            });

            services.AddDbContext<BookStoreContext>(options=>options.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=BookStore;Integrated Security=True;"));
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=BookStore;Integrated Security=True;"));
            services.AddControllersWithViews();
#if DEBUG
            
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            services.AddScoped<BookRespository,BookRespository>();
            services.AddScoped<EmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
 
             app.UseRouting();
             app.UseAuthentication();
            app.UseAuthorization();

             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapDefaultControllerRoute();
             });
        }
    }
}
