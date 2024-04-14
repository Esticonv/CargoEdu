using R7P.Application.Core.Repositories;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Application.Repositories;

public interface IOrderRepository : IRepository<Order, long>
{

}
