using R7P.DeliveryCalculationService.Application.Dtos;

namespace R7P.DeliveryCalculationService.Application.Services;

public interface IDeliveryCalculationService
{
    //Task<SegmentDto> GetById(long id);
    //Task<SegmentDto[]> GetAll(CancellationToken ct = default);
    Task<double> GetDistance(string departureAddress, string destinationAddress);
    Task SaveCalculation(CalculationDto[] calculations);
}