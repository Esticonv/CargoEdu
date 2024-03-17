namespace R7P.DeliveryCalculationService.Application.Services;

public interface IDeliveryCalculationService
{
    double GetDistance(long departureAddressId, long destinationAddressId, long machineId);
}