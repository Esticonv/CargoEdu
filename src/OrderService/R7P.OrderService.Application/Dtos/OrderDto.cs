namespace R7P.OrderService.Application.Dtos;

public class OrderDto
{
    public long Id { get; set; }

    public required decimal TotalPrice { get; set; }

    public required OrderStatus Status { get; set; }

    public required double CargoSize { get; set; }
    public required Guid CargoGuid { get; set; }

    public long CustomerId { get; set; }

    public CustomerDto? Customer { get; set; }

    public required string DepartureAddress { get; set; }

    public required string DestinationAddress { get; set; }
    public long MachineId { get; set; }
}
