using MediatR;
using R7P.Infrastructure.Core.Repositories;
using R7P.OrderService.Application.Repositories;
using R7P.OrderService.Domain.Entities;
using R7P.OrderService.Domain.Events;

namespace R7P.OrderService.Infrastructure.Data.Repositories;

public class OrderRepository(ApplicationDbContext context, IMediator mediator) 
    : Repository<Order, long>(context, mediator), IOrderRepository
{
    public override async Task<Order> AddAsync(Order entity)
    {
        Order addedEntity = await base.AddAsync(entity);
        addedEntity.AddDomainEvent(new OrderCreatedEvent
        {
            Order = addedEntity
        });

        return addedEntity;
    }
}
