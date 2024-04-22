namespace R7P.DeliveryCalculationService.Application.Dtos;

public class DeliverySpecificationDto
{
    public long Id { get; init; }

    public long DepartureAddressId { get; init; }

    public long DestinationAddressId { get; init; }
    
    public double Distance { get; init; }
}