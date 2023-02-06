using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Services;
using My_Books.Data.ViewModels;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private CountriesService _countriesService;
        public CountriesController(CountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpPost("add-country")]
        public IActionResult AddCountry([FromBody] CountryVM country)
        {
            _countriesService.AddCountry(country);
            return Ok(country);
        }
    }
}
