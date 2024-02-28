using MachineManagerService.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineManagerService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly ILogger<MachineController> _logger;

        public MachineController(ILogger<MachineController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMachine")]
        public IEnumerable<Models.MachineModel> Get()
        {
            return Enumerable.Range(1, 5)
                .Select(index => new MachineModel() {
                    Name = $"Stub Machine #{index}"
                    }
            );
        }
    }
}
