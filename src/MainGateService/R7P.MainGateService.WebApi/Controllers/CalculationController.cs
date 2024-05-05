using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R7P.SharedModels;

namespace R7P.MainGateService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController(IRequestClient<CalculateCost> client, IPublishEndpoint publishEndpoint) : ControllerBase
    {
        [HttpPost("{calculateCost}")]
        public async Task<IActionResult> RequestCalculations(CalculateCost calculateCost)
        {
            var response=await client.GetResponse<CalculateCostResult>(calculateCost);
            //await _publishEndpoint.Publish(calculateCost);

            return Ok(response.Message);
        }
    }
}
