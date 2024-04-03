using R7P.DeliveryCalculationService.Application.Dtos;

namespace R7P.DeliveryCalculationService.Application.Services;

public interface IDeliveryCalculationService
{
    Task<DeliverySpecificationDto> GetById(long id);
    Task<DeliverySpecificationDto[]> GetAll(CancellationToken ct = default);
    double GetDistance(long departureAddressId, long destinationAddressId, long machineId);
}