using R7P.Application.Core.Repositories;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Application.Repositories;

public interface ICustomerRepository : IRepository<Customer, long>
{

}
