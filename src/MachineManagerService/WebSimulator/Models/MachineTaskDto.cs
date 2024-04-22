namespace R7P.MachineManagerService.WebSimulator.Models
{
    public class MachineTaskDto
    {
        public int TaskOrder { get; set; }
        public int TaskType { get; set; }
        public string Departure { set; get; }
        public string Destination { set; get; }
        public double Progress { set; get; }

        public override string ToString()
        {
            return $"MachineTaskDto [TaskOrder: {TaskOrder}, TaskType: {TaskType}, Departure: {Departure}, Destination: {Destination}, Progress {Progress}]";
        }
    }
}
