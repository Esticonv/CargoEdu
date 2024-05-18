namespace R7P.SharedModels
{
    public record class UpdateOrder
    {
        public required long OrderId { get; set; }
        public required int Status { get; set; }
    }
}
