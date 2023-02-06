using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Services;
using My_Books.Data.ViewModels;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _puslishersService;
        public PublishersController(PublishersService puslishersService)
        {
            _puslishersService = puslishersService;
        }

        [HttpPost("add-puslisher")]
        public IActionResult AddPuslisher([FromBody] PublisherVM puslisher)
        {
            _puslishersService.AddPublisher(puslisher);
            return Ok(puslisher);
        }
    }
}
