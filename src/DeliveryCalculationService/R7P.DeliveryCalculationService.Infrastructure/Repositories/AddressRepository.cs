using R7P.DeliveryCalculationService.Application.Repositories;
using R7P.DeliveryCalculationService.Domain.Entities;

namespace R7P.DeliveryCalculationService.Infrastructure.Repositories;

public class AddressRepository(ApplicationDbContext context) : Repository<Address, long>(context), IAddressRepository
{
}