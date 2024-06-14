namespace R7P.DeliveryCalculationService.WebApi.Models
{
    public class MachineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Capacity { get; set; }
        public double MaxSpeed { get; set; }
        public decimal CostPerDistance { get; set; }
        public List<MachineTaskDto>? Tasks { get; set; }
        public List<CargoDto>? Сargoes { get; set; }
    }
}
