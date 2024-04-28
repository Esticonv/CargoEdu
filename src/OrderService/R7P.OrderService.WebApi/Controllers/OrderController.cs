using Microsoft.AspNetCore.Mvc;
using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Services;

namespace R7P.OrderService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IOrderService orderService, IHttpClientFactory httpClientFactory, IConfiguration configuration) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly IConfiguration _configuration=configuration;

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

    [HttpPut("createOrder/{customerId}&{calculationId}")]
    public async Task Add(long customerId, long calculationId)
    {
        var address = _configuration.GetSection("ServicesUri").GetValue<string>("DeliveryCalculationService_DeliveryCalculation");
        var http = _httpClientFactory.CreateClient();
        var calculation = await http.GetFromJsonAsync<Models.CalculationDto>($"{address}/{calculationId}");

        var order=new OrderDto {
            CustomerId = customerId,
            MachineId = calculation.MachineId,
            CargoSize = calculation.CargoSize,
            TotalPrice = calculation.Cost,
            DepartureAddress = calculation.DepartureAddress.AddressInfo,
            DestinationAddress = calculation.DestinationAddress.AddressInfo,
            Status = OrderStatus.Pending
        };

        await _orderService.Add(order);
    }
}
