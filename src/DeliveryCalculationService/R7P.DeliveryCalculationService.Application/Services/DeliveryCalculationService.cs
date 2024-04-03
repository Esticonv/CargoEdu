using R7P.DeliveryCalculationService.Application.Dtos;
using R7P.DeliveryCalculationService.Application.Repositories;

namespace R7P.DeliveryCalculationService.Application.Services;

public class DeliveryCalculationService(IDeliverySpecificationRepository repository) : IDeliveryCalculationService
{
    private readonly IDeliverySpecificationRepository _repository = repository;

    public async Task<DeliverySpecificationDto[]> GetAll(CancellationToken ct = default)
    {
        var deliverySpecifications = await _repository.GetAllAsync(ct);
        var result = deliverySpecifications.Select(ds => new DeliverySpecificationDto
        {
            Id = ds.Id,
        }).ToArray();

        return result;
    }

    public async Task<DeliverySpecificationDto> GetById(long id)
    {
        var ds = await _repository.GetAsync(id)
            ?? throw new Exception($"Не найдена характеристика доставки с идентифкатором {id}");

        return new DeliverySpecificationDto
        {
            Id = ds.Id,
        };
    }

    public double GetDistance(long departureAddressId, long destinationAddressId, long machineId)
    {
        return 1;
    }
}