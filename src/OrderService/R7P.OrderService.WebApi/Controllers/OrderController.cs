using Microsoft.AspNetCore.Mvc;
using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Services;

namespace R7P.OrderService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;

    [HttpGet("getById/{id}")]
    public async Task<OrderDto> Get(long id)
    {
        return await _orderService.GetById(id);
    }

    [HttpGet("getAll")]
    public async Task<OrderDto[]> GetAll()
    {
        return await _orderService.GetAll();
    }
       

    [HttpPut("createOrder/{calculationId}")]
    public async Task Add(long calculationId)
    {
        throw new NotImplementedException();
        //new OrderDto { }

        //await _orderService.Add(orderDto);
    }
}
