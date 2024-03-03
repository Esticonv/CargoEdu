using R7P.OrderService.Application.Repositories;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Repositories;

public class CustomerRepository(ApplicationDbContext context) : Repository<Customer, long>(context), ICustomerRepository
{
}
