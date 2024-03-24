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

        /*[HttpGet("Machine/{id}")]
        async public Task<MachineDto> Get(int id)
        {
             return await _machineService.GetById(id);
        }*/
    }
}
