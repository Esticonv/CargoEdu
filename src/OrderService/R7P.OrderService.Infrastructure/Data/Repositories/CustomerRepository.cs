using Microsoft.EntityFrameworkCore;
using R7P.OrderService.Application.Repositories;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Repositories;

public class CustomerRepository : Repository<Customer, long>, ICustomerRepository
{
    public CustomerRepository(DbContext context) : base(context)
    {
    }
}
