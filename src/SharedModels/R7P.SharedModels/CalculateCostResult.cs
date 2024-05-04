using System.Collections.Generic;

namespace R7P.SharedModels
{
    public record CalculateCostResult
    {
        public required List<OneCalculateCost> Calculations { get; set; }
    }

    public record OneCalculateCost
    {
        public long Id { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public decimal Cost { get; set; }
    }
}
