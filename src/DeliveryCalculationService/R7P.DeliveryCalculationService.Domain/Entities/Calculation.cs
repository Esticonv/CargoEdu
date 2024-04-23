namespace R7P.DeliveryCalculationService.Domain.Entities
{
    public class Calculation : IEntity<long>
    {
        public long Id { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public decimal Cost { get; set; }        
    }
}
