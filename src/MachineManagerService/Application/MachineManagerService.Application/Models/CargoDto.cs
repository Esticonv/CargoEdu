using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagerService.Application.Models
{
    public class CargoDto
    {
        public string? Destination { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
    }
}
