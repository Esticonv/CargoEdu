using Microsoft.AspNetCore.Mvc;
using R7P.MachineManagerService.Application.Models;
using R7P.MachineManagerService.Application.Interfaces;

namespace R7P.MachineManagerService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineController : ControllerBase
    {
        private readonly ILogger<MachineController> _logger;
        private readonly IMachineService _machineService;

        public MachineController(ILogger<MachineController> logger, IMachineService machineService)
        {
            _logger = logger;
            _machineService= machineService; 
        }

        [HttpGet("{id}")]
        async public Task<MachineDto> Get(int id)
        {
             return await _machineService.GetById(id);
        }

        [HttpGet()]
        async public Task<IEnumerable<MachineDto>> GetFiveIdle()
        {
            return await _machineService.GetFiveIdle();
        }

        [HttpPost]
        async public Task<MachineDto> Add(MachineDto machine)
        {            
            return await _machineService.Add(machine);
        }

        [HttpDelete("{id}")]
        async public Task<bool> Delete(int id)
        {
            return await _machineService.Delete(id);
        }
    }
}
