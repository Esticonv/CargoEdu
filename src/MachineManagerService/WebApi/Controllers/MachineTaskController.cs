using Microsoft.AspNetCore.Mvc;
using R7P.MachineManagerService.Application.Models;
using R7P.MachineManagerService.Application.Interfaces;

namespace R7P.MachineManagerService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineTaskController(ILogger<MachineTaskController> logger, IMachineTaskService machineTaskService) : ControllerBase
    {
        [HttpPut]
        async public Task Update(MachineTaskDto machineTask)
        {            
            await machineTaskService.UpdateAsync(machineTask);
            logger.LogInformation("Update {machineTask}", machineTask);
        }
    }
}
