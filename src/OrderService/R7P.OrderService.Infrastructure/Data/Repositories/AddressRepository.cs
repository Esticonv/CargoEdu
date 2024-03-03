using Microsoft.EntityFrameworkCore;
using R7P.OrderService.Application.Repositories;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Repositories;

public class AddressRepository : Repository<Address, long>, IAddressRepository
{
    public AddressRepository(DbContext context) : base(context)
    {
    }
}
