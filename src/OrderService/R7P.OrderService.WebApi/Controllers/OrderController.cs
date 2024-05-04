using Microsoft.AspNetCore.Mvc;
using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Services;

namespace R7P.OrderService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IOrderService orderService, IHttpClientFactory httpClientFactory, IConfiguration configuration) : ControllerBase
{
    [HttpGet("getById/{id}")]
    public async Task<OrderDto> Get(long id)
    {
        return await orderService.GetById(id);
    }

    [HttpGet("getAll")]
    public async Task<OrderDto[]> GetAll()
    {
        return await orderService.GetAll();
    }
}
