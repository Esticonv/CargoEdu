using R7P.DeliveryCalculationService.Application.Dtos;
using R7P.DeliveryCalculationService.Application.Mapping;
using R7P.DeliveryCalculationService.Application.Repositories;
using R7P.DeliveryCalculationService.Domain.Entities;

namespace R7P.DeliveryCalculationService.Application.Services;

public class DeliveryCalculationService(
    ISegmentRepository segmentRepository, 
    IAddressRepository addressRepository, 
    ICalculationRepository calculationRepository) : IDeliveryCalculationService
{
    private readonly ISegmentRepository _segmentRepository = segmentRepository;
    //private readonly IAddressRepository _addressRepository = addressRepository;
    private readonly ICalculationRepository _calculationRepository = calculationRepository;

    /*public async Task<SegmentDto[]> GetAll(CancellationToken ct = default)
    {
        var deliverySpecifications = await _repository.GetAllAsync(ct);
        var result = deliverySpecifications.Select(ds => new SegmentDto
        {
            Id = ds.Id,
        }).ToArray();

        return result;
    }*/

    public async Task<CalculationDto> GetById(long id)
    {
        var calculation = await _calculationRepository.GetAsync(id)
            ?? throw new ArgumentException($"Не найден расчёт доставки с идентификатором {id}");

        return CalculationMapper.ToDto(calculation);
    }

    public async Task<SegmentDto> GetDistance(string departureAddress, string destinationAddress)
    {
        var segment = _segmentRepository.GetAll(noTracking: true).Where(x => 
            (x.DestinationAddress.AddressInfo == departureAddress && x.DepartureAddress.AddressInfo == destinationAddress) ||
            (x.DestinationAddress.AddressInfo == destinationAddress && x.DepartureAddress.AddressInfo == departureAddress)).FirstOrDefault();

        if (segment is not null) {
            var result = Mapping.SegmentMapper.ToDto(segment) with { Id = -1 };
            return result;
        }
        else {
            return new SegmentDto { Distance = Double.NaN };
        }        
    }

    public async Task<CalculationDto[]> SaveCalculation(CalculationDto[] calculations)
    {
        var result = new List<CalculationDto>(calculations.Length);
        var domainCalculation=new List<Calculation>(calculations.Length);

        foreach (var calculation in calculations) {
            var entityCalculation = await _calculationRepository.AddAsync(CalculationMapper.ToDomain(calculation));
            domainCalculation.Add(entityCalculation);
        }

        await _calculationRepository.SaveChangesAsync();

        foreach (var calculation in domainCalculation) { 
            result.Add(CalculationMapper.ToDto(calculation));
        }

        return result.ToArray();
    }
}