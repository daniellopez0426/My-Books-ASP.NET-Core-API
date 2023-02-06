using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Books.Data.Services;
using My_Books.Data.ViewModels;

namespace My_Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private MachinesService _machinesService;
        public MachinesController(MachinesService machinesService)
        {
            _machinesService = machinesService;
        }

        [HttpPost("add-machine")]
        public IActionResult AddMachine([FromBody] MachineVM machine)
        {
            _machinesService.AddMachine(machine);
            return Ok(machine);
        }
    }
}
