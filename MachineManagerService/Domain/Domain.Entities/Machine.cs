namespace MachineManagerService.Domain.Entities
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double CargoCapacity { get; set; }
        public double MaxSpeed {  get; set; }

    }
}
