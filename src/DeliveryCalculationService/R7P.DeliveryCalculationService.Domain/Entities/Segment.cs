namespace R7P.DeliveryCalculationService.Domain.Entities;

public class Segment : IEntity<long>
{
    public long Id { get; set; }

    public long DepartureAddressId { get; set; }

    public Address DepartureAddress { get; set; }

    public long DestinationAddressId { get; set; }

    public Address DestinationAddress { get; set; }

    public double Distance { get; set; }
}