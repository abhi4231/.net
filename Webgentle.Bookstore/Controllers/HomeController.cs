using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Webgentle.Bookstore.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            ViewBag.Title = "Abhijit";

            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Abhi";

            ViewBag.Data = data;
            return View();
        }

        public ViewResult AboutUS()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
