using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R7P.SharedModels;

namespace R7P.MainGateService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController(IPublishEndpoint publishEndpoint) : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        [HttpPost("{orderDto}")]
        public async Task<IActionResult> CreateCalculation(CalculationRequestDto orderDto)
        {
            await _publishEndpoint.Publish(orderDto);
            return Ok();
        }
    }
}
