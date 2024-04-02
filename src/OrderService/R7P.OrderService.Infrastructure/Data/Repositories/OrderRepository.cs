using MassTransit;
using R7P.Domain.Core.Dtos;
using R7P.OrderService.Application.Repositories;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Repositories;

public class OrderRepository(ApplicationDbContext context, IPublishEndpoint publishEndpoint) : Repository<Order, long>(context), IOrderRepository
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public override async Task<Order> AddAsync(Order entity)
    {
        var addedEntity = await base.AddAsync(entity);

        await _publishEndpoint.Publish(new OrderCreatedEvent
        {
            Id = addedEntity.Id,
            DepartureAddress = addedEntity.DepartureAddress.AddressInfo,
            DestinationAddress = addedEntity.DestinationAddress.AddressInfo,
            TotalPrice = addedEntity.TotalPrice,
            Volume = addedEntity.Volume,
            Weight = addedEntity.Weight
        });

        return addedEntity;
    }
}
