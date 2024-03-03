using R7P.OrderService.Application.Repositories;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Repositories;

public class OrderRepository(ApplicationDbContext context) : Repository<Order, long>(context), IOrderRepository
{
}
