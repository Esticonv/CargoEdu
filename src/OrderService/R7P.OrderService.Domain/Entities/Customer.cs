namespace R7P.OrderService.Domain.Entities;

public class Customer : IEntity<long>
{
    public long Id { get; set; }
    
    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; }

    public ICollection<Order> Orders { get; set; } = null!;
}
