using R7P.OrderService.Domain.Enums;

namespace R7P.OrderService.Application.Dtos;

public class OrderDto
{
    public required decimal TotalPrice { get; init; }

    public required float Volume { get; init; }

    public required float Weight { get; init; }

    public required long CustomerId { get; init; }

    public required long DepartureAddressId { get; init; }

    public required long DestinationAddressId { get; init; }
}
