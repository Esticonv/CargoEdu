namespace R7P.MachineManagerService.WebSimulator.Models
{
    public class CargoDto
    {
        public string? Destination { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"CargoDto [Destination: {Destination}, Volume: {Volume}, Weight: {Weight}]";
        }
    }
}
