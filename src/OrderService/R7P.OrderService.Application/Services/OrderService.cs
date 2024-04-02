using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Repositories;
using R7P.OrderService.Domain.Entities;
using R7P.OrderService.Domain.Enums;

namespace R7P.OrderService.Application.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<long> Checkout(OrderDto orderDto)
    {
        Order order = new()
        {
            CustomerId = orderDto.CustomerId,
            DepartureAddressId = orderDto.DepartureAddressId,
            DestinationAddressId = orderDto.DestinationAddressId,
            Status = OrderStatus.Pending,
            TotalPrice = orderDto.TotalPrice,
            Volume = orderDto.Volume,
            Weight = orderDto.Weight
        };

        _orderRepository.Add(order);
        await _orderRepository.SaveChangesAsync();

        return order.Id;
    }
}
