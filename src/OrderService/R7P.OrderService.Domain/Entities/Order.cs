using R7P.OrderService.Domain.Enums;

namespace R7P.OrderService.Domain.Entities;

public class Order : IEntity<long>
{
    public long Id { get; set; }

    public required decimal TotalPrice { get; set; }

    public required OrderStatus Status { get; set;}
        
    public required float Volume  { get; set; }

    public required float Weight { get; set; }

    public required long CustomerId { get; set;}

    public required long DepartureAddressId { get; set; }

    public required long DestinationAddressId { get; set; }

    public Customer Customer { get; set; } = null!;

    public Address DepartureAddress { get; set; } = null!;

    public Address DestinationAddress { get; set; } = null!;
}
