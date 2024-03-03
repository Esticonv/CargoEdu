using MachineManagerService.Application.Models;

namespace MachineManagerService.WebApi.Models
{
    public class MachineModel
    {
        public string? Name { get; set; }
        public double VolumeCapacity { get; set; }
        public double WeightCapacity { get; set; }
        public double MaxSpeed { get; set; }
        public decimal CostPerDistance { get; set; }
        public List<MachineTaskDto>? Tasks { get; set; }
        public List<CargoDto>? Сargoes { get; set; }
    }
}
