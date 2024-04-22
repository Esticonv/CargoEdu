namespace R7P.MachineManagerService.Domain.Entities
{
    public class Cargo : IEntity<int>
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public virtual Machine? Machine { get; set; }
        public string? Destination { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
    }
}
