using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.Bookstore.Models;
using Webgentle.Bookstore.Respository;

namespace Webgentle.Bookstore.Controllers
{
    public class BookController : Controller
    {
         private readonly BookRespository _bookRespository = null;

        public BookController(BookRespository bookRespository)
        {
            _bookRespository =  bookRespository;
        }
        public async Task <ViewResult> GetAllBooks()
        {
            var data= await _bookRespository.GetAllBooks();
            return View(data);
        }
        
        public async Task <ViewResult> GetBook(int id)
        {
            var data = await _bookRespository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookname, string authorName)
        {
            return _bookRespository.SearchBook(bookname, authorName);
        }

        public ViewResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult>  AddNewBook(BookModel bookModel)
        {
            
            int id= await _bookRespository.AddNewBook(bookModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBook));
            }
            return View();
        }
    }
}
