namespace R7P.DeliveryCalculationService.Domain.Entities;

public class MachineTask : IEntity<long>
{
    public long Id { get; set; }
    public int MachineId { get; set; }
    public Machine? Machine { get; set; }

    /// <summary>
    /// One machine can have 0 to many Task.
    /// Task executing by order. Lesser value - higher priority
    /// </summary>
    public int TaskOrder { get; set; }

    /// <summary>
    /// Idle, Moving
    /// </summary>
    public int TaskType { get; set; }

    public string? Departure { set; get; }
    public string? Destination { set; get; }

    /// <summary>
    /// 0 - start, 1 - finish
    /// 0 to 1
    /// </summary>
    public double Progress { set; get; }
}
