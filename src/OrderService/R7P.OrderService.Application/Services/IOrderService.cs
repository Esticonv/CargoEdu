using R7P.OrderService.Application.Dtos;

namespace R7P.OrderService.Application.Services;

public interface IOrderService
{
    Task<OrderDto> GetById(long id);

    Task<OrderDto[]> GetAll();

    Task Add(OrderDto dto);
}
