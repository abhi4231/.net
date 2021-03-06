using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Webgentle.Bookstore.Data;
using Webgentle.Bookstore.Models;

namespace Webgentle.Bookstore.Respository
{
    public class BookRespository
    {
        private readonly BookStoreContext _context = null;

        public BookRespository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                UpdatedOn = DateTime.UtcNow,
                TotalPages = model.TotalPages,
                Title = model.Title
            };

           await _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();

            return newBook.Id;
        }

        private BookStoreContext SaveChanges()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any()==true)
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author=book.Author,
                        Category=book.Category,
                        Description=book.Description,
                        Id=book.Id,
                        Language=book.Language,
                        Title=book.Title,
                        TotalPages=book.TotalPages
                    });
                }
            }
            return books;
        }

        public async Task<BookModel>  GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            return null;
         
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName) ).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() {Id = 1, Title = "MVC", Author = "Nitish",Description="This Book is regarding MVC",Category = "Educational",Language = "Bengali",TotalPages = 134},
                new BookModel() {Id = 2, Title = "Core", Author = "Ketan",Description="This Book is regarding Core",Category = "Educational",Language = "Sanskrit",TotalPages = 134},
                new BookModel() {Id = 3, Title = "EF", Author = "Pravin",Description="This Book is regarding EF",Category = "Educational",Language = "Hindi",TotalPages = 134},
                new BookModel() {Id = 4, Title = "C#", Author = "Arnav",Description="This Book is regarding C#",Category = "Educational",Language = "English",TotalPages = 134},
                new BookModel() {Id = 5, Title = "Cpp", Author = "Arnav",Description="This Book is regarding C#",Category = "Educational",Language = "Marathi",TotalPages = 134},

            };
        }
            }
}
