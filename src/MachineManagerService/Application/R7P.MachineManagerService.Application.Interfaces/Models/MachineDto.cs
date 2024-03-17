using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7P.MachineManagerService.Application.Models
{
    public class MachineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double VolumeCapacity { get; set; }
        public double WeightCapacity { get; set; }
        public double MaxSpeed { get; set; }
        public decimal CostPerDistance { get; set; }
        public List<MachineTaskDto>? Tasks { get; set; }
        public List<CargoDto>? Сargoes { get; set; }
    }
}
