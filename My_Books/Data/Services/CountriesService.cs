using My_Books.Data.Models;
using My_Books.Data.ViewModels;
using System;

namespace My_Books.Data.Services
{
    public class CountriesService
    {
        private AppDbContext _context;
        public CountriesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddCountry(CountryVM country)
        {
            var _country = new Country()
            {
                Name = country.Name
            };
            _context.Countries.Add(_country);
            _context.SaveChanges();
        }

    }
}
