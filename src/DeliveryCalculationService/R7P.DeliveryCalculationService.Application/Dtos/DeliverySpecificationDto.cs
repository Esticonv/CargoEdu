namespace R7P.DeliveryCalculationService.Application.Dtos;

public class DeliverySpecificationDto
{
    public long DepartureAddressId { get; set; }

    public long DestinationAddressId { get; set; }
    
    public double Distance { get; set; }
}