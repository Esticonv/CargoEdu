using R7P.OrderService.Domain.Enums;

namespace R7P.OrderService.Domain.Entities;

public class Order : IEntity<long>
{
    public long Id { get; set; }

    public required decimal TotalPrice { get; set; }

    public required OrderStatus Status { get; set;}

    public required Guid CargoGuid { get; set; }
        
    public required double CargoSize  { get; set; }

    public long CustomerId { get; set;}

    public Customer? Customer { get; set; }
    
    public required string DepartureAddress { get; set; }

    public required string DestinationAddress { get; set; }

    public long MachineId {  get; set; }
}
