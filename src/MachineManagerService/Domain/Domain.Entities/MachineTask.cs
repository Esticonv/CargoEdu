namespace R7P.MachineManagerService.Domain.Entities
{
    public class MachineTask : IEntity<long>
    {
        public long Id { get; set; }
        public long MachineId { get; set; }
        public virtual Machine? Machine {get;set;}

        public long? CargoId { get; set; }
        public virtual Cargo? Cargo { get; set; } 

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
