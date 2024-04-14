using MediatR;
using R7P.OrderService.Application.Repositories;
using R7P.OrderService.Domain.Entities;
using R7P.OrderService.Domain.Enums;

namespace R7P.OrderService.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<long>
{
    public required decimal TotalPrice { get; init; }

    public required float Volume { get; init; }

    public required float Weight { get; init; }

    public required long CustomerId { get; init; }

    public required long DepartureAddressId { get; init; }

    public required long DestinationAddressId { get; init; }
}

internal class CreateOrderCommandHandler(IOrderRepository orderRepository) : IRequestHandler<CreateOrderCommand, long>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = new()
        {
            CustomerId = request.CustomerId,
            DepartureAddressId = request.DepartureAddressId,
            DestinationAddressId = request.DestinationAddressId,
            Status = OrderStatus.Pending,
            TotalPrice = request.TotalPrice,
            Volume = request.Volume,
            Weight = request.Weight
        };

        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
