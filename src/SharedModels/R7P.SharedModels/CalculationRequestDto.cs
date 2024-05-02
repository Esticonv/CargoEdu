namespace R7P.SharedModels
{
    public record class CalculationRequestDto
    {
        public required string From { get; set; }
        public required string To { get; set; }
        public required double Size { get; set; }
    }
}
