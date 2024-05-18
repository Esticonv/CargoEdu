namespace R7P.MachineManagerService.Application.Models
{
    public class MachineTaskDto
    {
        public long Id { get; set; }
        public long MachineId { get; set; }
        public int TaskOrder { get; set; }
        public int TaskType { get; set; }
        public string Departure { set; get; }
        public string Destination { set; get; }
        public double Progress { set; get; }
    }
}
