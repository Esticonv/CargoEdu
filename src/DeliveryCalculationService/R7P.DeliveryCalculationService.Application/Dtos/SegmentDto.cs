namespace R7P.DeliveryCalculationService.Application.Dtos;

public class SegmentDto
{
    public long Id { get; init; }

    public long DepartureAddressId { get; init; }

    public string DepartureAddress {  get; set; }

    public long DestinationAddressId { get; init; }

    public string DestinationAddress { get; set; }
    
    public double Distance { get; init; }
}