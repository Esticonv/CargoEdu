using MassTransit;
using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Services;
using R7P.SharedModels;


namespace R7P.OrderService.WebApi.Consumers;

internal class UpdateOrderConsumer(
    ILogger<UpdateOrderConsumer> logger,
    IOrderService orderService,
    IHttpClientFactory httpClientFactory, 
    IConfiguration configuration) 
    : IConsumer<UpdateOrder>
{
    public async Task Consume(ConsumeContext<UpdateOrder> context)
    {
        logger.LogInformation($"Consume {context.Message}");               
        
        await orderService.UpdateAsync(context.Message.OrderId, (OrderStatus)context.Message.Status);
    }
}