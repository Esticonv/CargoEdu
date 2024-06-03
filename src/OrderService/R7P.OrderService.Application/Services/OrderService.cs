using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Repositories;

namespace R7P.OrderService.Application.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public async Task<OrderDto[]> GetAll()
    {
        var orders = await orderRepository.GetAllAsync(CancellationToken.None);
        var result = orders.Select(x => Mapping.OrderMapper.ToDto(x)).ToArray();

        return result;
    }

    public async Task<OrderDto> GetById(long id)
    {
        var order = await orderRepository.GetAsync(id)
            ?? throw new ArgumentException($"Не найден адрес с идентификатором {id}");

        return Mapping.OrderMapper.ToDto(order);
    }

    public async Task Add(OrderDto dto)
    {
        await orderRepository.AddAsync(Mapping.OrderMapper.ToDomain(dto));
        await orderRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(long orderId, OrderStatus orderStatus)
    {
        var order = await orderRepository.GetAsync(orderId)
            ?? throw new ArgumentException($"Не найден адрес с идентификатором {orderId}");

        order.Status = (Domain.Enums.OrderStatus)orderStatus;
        await orderRepository.SaveChangesAsync();
    }
}
