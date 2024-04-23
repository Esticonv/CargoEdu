namespace R7P.DeliveryCalculationService.Application.Dtos
{
    public class CalculationDto
    {
        public int Id { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public decimal Cost {  get; set; }
    }
}
