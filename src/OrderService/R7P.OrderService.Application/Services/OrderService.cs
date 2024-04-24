using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Repositories;

namespace R7P.OrderService.Application.Services;

public class OrderService(IOrderRepository addressRepository) : IOrderService
{
    private readonly IOrderRepository _addressRepository = addressRepository;

    public async Task<OrderDto[]> GetAll()
    {
        var orders = await _addressRepository.GetAllAsync(CancellationToken.None);
        var result = orders.Select(x => Mapping.OrderMapper.ToDto(x)).ToArray();

        return result;
    }

    public async Task<OrderDto> GetById(long id)
    {
        var order = await _addressRepository.GetAsync(id)
            ?? throw new ArgumentException($"Не найден адрес с идентификатором {id}");

        return Mapping.OrderMapper.ToDto(order);
    }

    public async Task Add(OrderDto dto)
    {
        await _addressRepository.AddAsync(Mapping.OrderMapper.ToDomain(dto));
    }
}
