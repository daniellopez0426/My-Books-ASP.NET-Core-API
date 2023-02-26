using My_Books.Data.Models;
using My_Books.Data.Paging;
using My_Books.Data.ViewModels;
using My_Books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace My_Books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public List<Publisher> GetAllPublishers(string sortBy, string searchString, int? pageNumber) 
        { 
            var allPublishers = _context.Publisher.OrderBy(n => n.Name).ToList();

            if(!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            if(!string.IsNullOrEmpty(searchString))
            {
               allPublishers = allPublishers.Where(n => n.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            //paging
            int pageSize = 3;
            allPublishers = PaginatedList<Publisher>.Create(allPublishers.AsQueryable(), pageNumber ?? 1, pageSize);

            return allPublishers;
        }
        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringStartWithNumber(publisher.Name)) throw new PublisherNameException("Name Start with Numbers", publisher.Name);

            var _publisher = new Publisher()
            {
                Name = publisher.Name               
            };
            _context.Publisher.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherById(int id) =>  _context.Publisher.FirstOrDefault(x => x.Id == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publisher.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Title,
                        BookAuthors = n.Book_Author.Select(n => n.Author.FullName).ToList()
                    }).ToList(),
                }).FirstOrDefault();
            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publisher.FirstOrDefault(n => n.Id == id);

            if(_publisher != null)
            {
                _context.Publisher.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with the Id {id} does not exist");
            }
        }

        private bool StringStartWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
    }
}
