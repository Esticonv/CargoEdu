namespace R7P.MachineManagerService.Application.Models
{
    public class CargoDto
    {
        public string? Destination { get; set; }
        public double Size { get; set; }
        public Guid CargoGuid { get; set; }
        public long? MachineId { get; set; }
    }
}
