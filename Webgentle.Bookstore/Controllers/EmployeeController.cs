using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;
using Webgentle.Bookstore.Repository;

namespace Webgentle.Bookstore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _EmployeeRespository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private int id;

        public EmployeeController(EmployeeRepository EmployeeRespository, IWebHostEnvironment webHostEnvironment)
        {
            _EmployeeRespository = EmployeeRespository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task <ViewResult> GetAllEmployees()
        {
            var data = await _EmployeeRespository.GetAllEmployees();
            return View(data);
        }

        public async Task<ViewResult> GetEmployees(int id)
        {
            var data = await _EmployeeRespository.GetEmployeeById(id);
            return View(data);
        }

        public List<EmployeeModel> SearchEmployee(int Id, string PAN)
        {
            return _EmployeeRespository.SearchEmployee(Id, PAN);
        }

        [Authorize]
        public async Task <ViewResult> AddNewEmployee()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> AddNewEmployee(EmployeeModel bookModel)
        {
             if (bookModel.ProfileImage != null)
            {
                string folder = "Employees/profile";
                folder += Guid.NewGuid().ToString() +  "_"+ bookModel.ProfileImage.FileName ;
                bookModel.ProfileImageUrl = folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

              await  bookModel.ProfileImage.CopyToAsync(new FileStream(serverFolder,FileMode.Create)); ;

            }

            if (bookModel.EmployeeDoc != null)
            {
                string folder = "Employees/pdf";
               // bookModel.EmployeePdfUrl=await UploadPdf
              //  folder += bookModel.EmployeeDoc.FileName + Guid.NewGuid().ToString();
               // string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                //await bookModel.EmployeeDoc.CopyToAsync(new FileStream(serverFolder, FileMode.Create)); ;


               

            }

            int id = await _EmployeeRespository.AddNewEmployee(bookModel);
            if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewEmployee));
                }
            
            return View();
        }
    }
}
