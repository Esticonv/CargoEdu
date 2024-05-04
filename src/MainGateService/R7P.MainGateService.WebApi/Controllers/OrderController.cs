using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R7P.SharedModels;

namespace R7P.MainGateService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IRequestClient<CreateOrder> client) : ControllerBase
    {
        [HttpPost()]
        public async Task<IActionResult> CreateOrder(CreateOrder createOrder)
        {
            var response=await client.GetResponse<CreateOrderResult>(createOrder);

            return Ok(response.Message);
        }
    }
}
