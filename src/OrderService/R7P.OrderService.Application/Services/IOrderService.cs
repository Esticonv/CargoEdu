using R7P.OrderService.Application.Dtos;

namespace R7P.OrderService.Application.Services;

public interface IOrderService
{
    Task<long> Checkout(OrderDto orderDto);
}