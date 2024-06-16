using R7P.DeliveryCalculationService.Application.Dtos;
using R7P.DeliveryCalculationService.Application.Mapping;
using R7P.DeliveryCalculationService.Application.Repositories;
using R7P.DeliveryCalculationService.Domain.Entities;
using System.Runtime.InteropServices;
using System.Xml.Linq;

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
    }*/

    public async Task<CalculationDto> GetById(long id)
    {
        var calculation = await _calculationRepository.GetAsync(id)
            ?? throw new ArgumentException($"Не найден расчёт доставки с идентификатором {id}");

        return CalculationMapper.ToDto(calculation);
    }

    public async Task<SegmentDto[]> GetDistanceAsync2(string departureAddress, string destinationAddress)
    {
        if (departureAddress == destinationAddress) {
            throw new ArgumentException("Same origin and destination");
        }

        //линейный обход всех сегментов
        var segments = (await _segmentRepository.GetAllAsync(CancellationToken.None, asNoTracking: true)).ToList();

        var start = segments.FirstOrDefault(x => HasAddress(x, departureAddress));

        var path = new List<Segment> {
            start
        };
        string lastAddress = Another(start, departureAddress);
        
        segments.Remove(start);
                
        while (true) {
            if(lastAddress == destinationAddress) break;

            var next = segments.FirstOrDefault(x => HasAddress(x, lastAddress));
            if (next != null) {
                path.Add(next);
                lastAddress = Another(next, lastAddress);
                segments.Remove(next);
            }
            else {
                throw new InvalidOperationException("Path not founded");
            }
            
        }
        return SegmentMapper.ToDto([..path]);
    }


    record class AddressAndTag(Address Address, double Tag, bool Visited=false) 
    {
        public Address Address { get; set; } = Address;
        public double Tag { get; set; } = Tag;
        public bool Visited { get; set; } = Visited;

        public AddressAndTag? Previous { get; set; }
    } 

    public async Task<SegmentDto[]> GetDistanceAsync(string departureAddress, string destinationAddress)
    {   
        //Dijkstra’s algorithm
        if (departureAddress == destinationAddress) {
            throw new ArgumentException("Same origin and destination");
        }

        var segments = (await _segmentRepository.GetAllAsync(CancellationToken.None, asNoTracking: true)).ToArray();
        var nodes = (await _addressRepository.GetAllAsync(CancellationToken.None, asNoTracking: true)).ToArray();

        var nodeAndTags = new List<AddressAndTag>();

        foreach (var node in nodes) {
            nodeAndTags.Add(new AddressAndTag(node, double.MaxValue));
        }

        var departureNode = nodeAndTags.First(x => x.Address.AddressInfo == departureAddress);
        var destinationNode = nodeAndTags.First(x => x.Address.AddressInfo == destinationAddress);
        departureNode.Tag = 0;

        var currentNode = departureNode;

        while (currentNode != null) {
            var adjacentSegments = segments.Where(x => HasAddress(x, currentNode.Address.AddressInfo));
            foreach (var segment in adjacentSegments) {
                var anotherNode = nodeAndTags.First(x => x.Address.AddressInfo == Another(segment, currentNode.Address.AddressInfo));
                if (anotherNode.Visited == false) {
                    anotherNode.Tag = currentNode.Tag + segment.Distance;
                    anotherNode.Previous = currentNode;
                }                
            }   
            currentNode.Visited = true;
            currentNode = nodeAndTags.Where(x => x.Visited == false).OrderBy(x => x.Tag).FirstOrDefault();
        }

        if (destinationNode.Tag == double.MaxValue) {
            throw new InvalidOperationException("Path not found");
        }

        var path = new List<Segment>();
        
        AddressAndTag? iteratorNode = destinationNode; 
        while (iteratorNode.Previous != null) {
            var segment = segments.First(x => HasAddress(x, iteratorNode.Address.AddressInfo) && HasAddress(x, iteratorNode.Previous.Address.AddressInfo));
            path.Add(segment);
            iteratorNode = iteratorNode.Previous;
        }
        path.Reverse();

        return SegmentMapper.ToDto([..path]);
    }

    private static bool HasAddress(Segment segment, string adress)
    {
        return segment.DepartureAddress.AddressInfo == adress || segment.DestinationAddress.AddressInfo == adress;
    }

    private static string Another(Segment segment, string from)
    {
        if (segment.DepartureAddress.AddressInfo == from) {
            return segment.DestinationAddress.AddressInfo;
        }
        else if (segment.DestinationAddress.AddressInfo == from) {
            return segment.DepartureAddress.AddressInfo;
        }
        else {
            throw new InvalidOperationException("Not found");
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

    public async Task<AddressDto> GetAddressAsync(string address)
    {
        var result = await _addressRepository.GetAllAsync(CancellationToken.None, asNoTracking: true);
        return AddressMapper.ToDto(result.FirstOrDefault(x => x.AddressInfo == address));
    }
}