using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagerService.Domain.Entities
{
    public class MachineTask
    {
        public int MachineTaskId { get; set; }
        public int MachineId { get; set; }
        public Machine? Machine {get;set;}

        /// <summary>
        /// One machine can have 0 to many Task.
        /// Task executing by order. Lesser value - higher priority
        /// </summary>
        public int TaskOrder { get; set; }

        /// <summary>
        /// Idle, Moving
        /// </summary>
        public int TaskType { get; set;}

        public string? Departure { set; get; }
        public string? Destination { set; get; }

        /// <summary>
        /// 0 - start, 1 - finish
        /// 0 to 1
        /// </summary>
        public double Progress { set; get; }

        
    }
}
