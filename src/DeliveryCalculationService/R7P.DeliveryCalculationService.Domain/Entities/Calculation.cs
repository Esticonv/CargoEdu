namespace R7P.DeliveryCalculationService.Domain.Entities
{
    public class Calculation : IEntity<long>
    {
        public long Id { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public decimal Cost { get; set; }

        public long DepartureAddressId { get; set; }
        public virtual Address? DepartureAddress { get; set; }
        public long DestinationAddressId { get; set; }
        public virtual Address? DestinationAddress { get; set; }

        public long MachineId { get; set; }
        public double CargoSize { get; set; }
    }
}
