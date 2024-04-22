﻿namespace R7P.DeliveryCalculationService.Domain.Entities;

public class Machine : IEntity<long>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public double VolumeCapacity { get; set; }
    public double WeightCapacity { get; set; }
    public double MaxSpeed { get; set; }
    public decimal CostPerDistance { get; set; }
    public List<MachineTask>? Tasks { get; set; }
    public List<Cargo>? Сargoes { get; set; }
}
