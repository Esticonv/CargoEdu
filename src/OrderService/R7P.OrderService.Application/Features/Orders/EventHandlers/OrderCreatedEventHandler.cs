using MassTransit;
using MediatR;
using R7P.Domain.Core.Dtos;
using R7P.OrderService.Domain.Entities;
using R7P.OrderService.Domain.Events;

namespace R7P.OrderService.Application.Features.Orders.EventHandlers;

public class OrderCreatedEventHandler(IPublishEndpoint publisher) : INotificationHandler<OrderCreatedEvent>
{
    private readonly IPublishEndpoint _publisher = publisher;

    public async Task Handle(OrderCreatedEvent orderCreatedEvent, CancellationToken cancellationToken)
    {
        Order order = orderCreatedEvent.Order;
        OrderCreatedMessage message = new()
        {
            Id = order.Id,
            DepartureAddress = order.DepartureAddress.AddressInfo,
            DestinationAddress = order.DestinationAddress.AddressInfo,
            Volume = order.Volume,
            Weight = order.Weight,
            TotalPrice = order.TotalPrice,
        };

        await _publisher.Publish(message, cancellationToken);
    }
}
