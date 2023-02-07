using My_Books.Data.Models;
using My_Books.Data.ViewModels;
using System;
using System.Linq;

namespace My_Books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName               
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BooksTitles = n.Book_Author.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }

    }
}
