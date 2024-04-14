using R7P.Domain.Core.Events;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Domain.Events;

public class OrderCreatedEvent : BaseEvent
{
    public required Order Order { get; init; }
}
