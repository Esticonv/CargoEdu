using Microsoft.EntityFrameworkCore;
using R7P.OrderService.Application.Repositories;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Repositories;

public class OrderRepository : Repository<Order, long>, IOrderRepository
{
    public OrderRepository(DbContext context) : base(context)
    {
    }
}
