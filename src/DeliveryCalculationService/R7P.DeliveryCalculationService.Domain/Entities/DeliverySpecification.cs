namespace R7P.DeliveryCalculationService.Domain.Entities;

public class DeliverySpecification : IEntity<long>
{
    public long Id { get; set; }

    public long DepartureAddressId { get; set; }

    public long DestinationAddressId { get; set; }

    public double Distance { get; set; }
}