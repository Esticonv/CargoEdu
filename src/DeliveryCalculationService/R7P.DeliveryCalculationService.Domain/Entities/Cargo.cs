namespace R7P.DeliveryCalculationService.Domain.Entities;

public class Cargo : IEntity<long>
{
    public long Id { get; set; }
    public int MachineId { get; set; }
    public Machine? Machine { get; set; }
    public string? Destination { get; set; }
    public double Volume { get; set; }
    public double Weight { get; set; }
}
