using R7P.DeliveryCalculationService.Application.Dtos;

namespace R7P.DeliveryCalculationService.Application.Services;

public interface IDeliveryCalculationService
{
    Task<AddressDto> GetAddressAsync(string address);
    Task<CalculationDto> GetById(long id);
    //Task<SegmentDto[]> GetAll(CancellationToken ct = default);
    Task<SegmentDto[]> GetDistanceAsync(string departureAddress, string destinationAddress);
    Task<CalculationDto[]> SaveCalculation(CalculationDto[] calculations);
}