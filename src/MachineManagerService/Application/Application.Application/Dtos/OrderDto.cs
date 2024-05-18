namespace R7P.MachineManagerService.Application.Dtos;

public class OrderDto
{
    public long Id { get; set; }

    public required decimal TotalPrice { get; set; }

    public required OrderStatus Status { get; set; }

    public required double CargoSize { get; set; }

    public required string DepartureAddress { get; set; }

    public required string DestinationAddress { get; set; }
    public long MachineId { get; set; }
}
