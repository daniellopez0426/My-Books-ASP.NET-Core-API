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
            var newPublisher = _puslishersService.AddPublisher(puslisher);
            return Created(nameof(AddPuslisher),newPublisher);
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _puslishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpGet("get-publisher-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _puslishersService.GetPublisherById(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _puslishersService.DeletePublisherById(id);
            return Ok();
        }
    }
}
