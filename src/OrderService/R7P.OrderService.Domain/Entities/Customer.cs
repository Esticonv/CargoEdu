using R7P.Domain.Core.Entities;

namespace R7P.OrderService.Domain.Entities;

public class Customer : BaseEntity
{   public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Phone { get; set; }

    public ICollection<Order> Orders { get; set; } = null!;
}
