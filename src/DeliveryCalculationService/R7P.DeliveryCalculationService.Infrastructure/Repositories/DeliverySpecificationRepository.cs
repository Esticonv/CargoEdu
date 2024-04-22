using R7P.DeliveryCalculationService.Application.Repositories;
using R7P.DeliveryCalculationService.Domain.Entities;

namespace R7P.DeliveryCalculationService.Infrastructure.Repositories;

public class DeliverySpecificationRepository(ApplicationDbContext context) : Repository<DeliverySpecification, long>(context), IDeliverySpecificationRepository
{
}