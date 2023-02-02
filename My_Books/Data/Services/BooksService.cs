using my_books.Data.Models;
using My_Books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_Books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context) 
        {
            _context = context;
        }

        public void AddBook (BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                Author = book.Author,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks() =>  _context.Books.ToList();

        public Book GetBookById(int id) => _context.Books.FirstOrDefault(x => x.Id == id);
         
    }
}
