using R7P.Domain.Core.Entities;

namespace R7P.OrderService.Domain.Entities;

public class Address : BaseEntity
{
    public required string AddressInfo { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set;}

    public required string PhoneNumber { get; set;}
}
