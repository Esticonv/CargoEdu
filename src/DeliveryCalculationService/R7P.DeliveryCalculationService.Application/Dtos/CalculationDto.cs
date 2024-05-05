namespace R7P.DeliveryCalculationService.Application.Dtos
{
    public class CalculationDto
    {
        public long Id { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public decimal Cost {  get; set; }
        public long DepartureAddressId {  get; set; }
        public AddressDto? DepartureAddress {  get; set; }
        public long DestinationAddressId { get; set; }
        public AddressDto? DestinationAddress {  get; set; }
        public double CargoSize { get; set; }
        public long MachineId {  get; set; }
    }
}
