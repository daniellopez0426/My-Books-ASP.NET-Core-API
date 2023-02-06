using My_Books.Data.Models;
using My_Books.Data.ViewModels;
using System;

namespace My_Books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name               
            };
            _context.Publisher.Add(_publisher);
            _context.SaveChanges();
        }

    }
}
