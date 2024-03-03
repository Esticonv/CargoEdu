namespace R7P.OrderService.Application.Dtos;

public class AddressDto
{
    public long Id { get; init; }

    public required string AddressInfo { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public required string PhoneNumber { get; init; }
}
