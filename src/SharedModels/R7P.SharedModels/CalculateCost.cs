namespace R7P.SharedModels
{
    public record class CalculateCost
    {
        public required string From { get; set; }
        public required string To { get; set; }
        public required double Size { get; set; }
    }
}
