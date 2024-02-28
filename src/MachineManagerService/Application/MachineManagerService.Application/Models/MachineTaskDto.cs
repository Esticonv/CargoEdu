using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagerService.Application.Models
{
    public class MachineTaskDto
    {
        public int TaskOrder { get; set; }
        public int TaskType { get; set; }
        public string Departure { set; get; }
        public string Destination { set; get; }
        public double Progress { set; get; }
    }
}
