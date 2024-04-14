namespace R7P.Domain.Core.Dtos;

public class OrderCreatedMessage
{
    public required long Id { get; init; }

    public required decimal TotalPrice { get; init; }

    public required float Volume { get; init; }

    public required float Weight { get; init; }

    public required string DepartureAddress { get; init; }

    public required string DestinationAddress { get; init; }
}
