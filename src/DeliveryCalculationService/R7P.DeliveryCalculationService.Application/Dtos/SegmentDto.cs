namespace R7P.DeliveryCalculationService.Application.Dtos;

public record class SegmentDto
{
    public long Id { get; init; }

    public long DepartureAddressId { get; set; }
    public AddressDto? DepartureAddress {  get; set; }
    public long DestinationAddressId { get; set; }
    public AddressDto? DestinationAddress { get; set; }    
    public double Distance { get; init; }
}