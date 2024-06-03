namespace R7P.MachineManagerService.Domain.Entities
{
    public class Cargo : IEntity<long>
    {
        public long Id { get; set; }
        public long MachineId { get; set; }
        public virtual Machine? Machine { get; set; }
        public string? Destination { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
    }
}
