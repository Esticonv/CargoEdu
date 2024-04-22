namespace R7P.DeliveryCalculationService.WebApi.Models
{
    public class CalculationDto
    {
        public int Id { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public decimal Cost {  get; set; }
        public string Comment { get; set; }
    }
}
