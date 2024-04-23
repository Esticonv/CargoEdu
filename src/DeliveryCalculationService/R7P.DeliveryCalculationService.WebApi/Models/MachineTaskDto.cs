namespace R7P.DeliveryCalculationService.WebApi.Models
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
