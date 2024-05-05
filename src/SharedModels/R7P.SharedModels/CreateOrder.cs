namespace R7P.SharedModels
{
    public record class CreateOrder
    {
        public required long CustomerId { get; set; }
        public required long CalculationId { get; set; }
    }
}
