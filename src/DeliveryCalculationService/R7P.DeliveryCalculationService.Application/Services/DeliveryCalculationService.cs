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
    private readonly IAddressRepository _addressRepository = addressRepository;
    private readonly ICalculationRepository _calculationRepository = calculationRepository;

    /*public async Task<SegmentDto[]> GetAll(CancellationToken ct = default)
    {
        var deliverySpecifications = await _repository.GetAllAsync(ct);
        var result = deliverySpecifications.Select(ds => new SegmentDto
        {
            Id = ds.Id,
        }).ToArray();

        return result;
    }

    public async Task<SegmentDto> GetById(long id)
    {
        var ds = await _repository.GetAsync(id)
            ?? throw new Exception($"Не найдена характеристика доставки с идентифкатором {id}");

        return new SegmentDto
        {
            Id = ds.Id,
        };
    }*/

    public async Task<double> GetDistance(string departureAddress, string destinationAddress)
    {
        var address = _addressRepository.GetAll().Where(x => x.AddressInfo == departureAddress || x.AddressInfo == destinationAddress).Take(2).ToArray();
        var segment = _segmentRepository.GetAll().Where(x => 
            (x.DestinationAddress == address[0] && x.DepartureAddress == address[1]) ||
            (x.DestinationAddress == address[1] && x.DepartureAddress == address[0])).FirstOrDefault();

        return segment?.Distance ?? double.NaN;
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