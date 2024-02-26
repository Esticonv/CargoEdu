using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagerService.Domain.Entities
{
    public class Cargo
    {
        public int CargoId { get; set; }
        public string Destination { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
    }
}
