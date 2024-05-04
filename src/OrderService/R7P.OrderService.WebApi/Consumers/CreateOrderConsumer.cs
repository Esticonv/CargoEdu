using MassTransit;
using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Services;
using R7P.SharedModels;


namespace R7P.OrderService.WebApi.Consumers;

internal class CreateOrderConsumer(
    ILogger<CreateOrderConsumer> logger,
    IOrderService orderService,
    IHttpClientFactory httpClientFactory, 
    IConfiguration configuration) 
    : IConsumer<CreateOrder>
{
    public async Task Consume(ConsumeContext<CreateOrder> context)
    {
        logger.LogInformation($"Consume {context.Message}");               

        var address = configuration.GetSection("ServicesUri").GetValue<string>("DeliveryCalculationService_DeliveryCalculation");
        var http = httpClientFactory.CreateClient();
        var calculation = await http.GetFromJsonAsync<Models.CalculationDto>($"{address}/{context.Message.CalculationId}") 
            ?? throw new InvalidOperationException("Bad request to CalculationDto");

        var order = new OrderDto {
            CustomerId = context.Message.CustomerId,
            MachineId = calculation.MachineId,
            CargoSize = calculation.CargoSize,
            TotalPrice = calculation.Cost,
            DepartureAddress = calculation.DepartureAddress.AddressInfo,
            DestinationAddress = calculation.DestinationAddress.AddressInfo,
            Status = OrderStatus.Pending
        };

        await orderService.Add(order);

        await context.RespondAsync(new CreateOrderResult());
    }
}