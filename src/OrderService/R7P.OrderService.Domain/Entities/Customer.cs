namespace R7P.OrderService.Domain.Entities;

public class Customer : IEntity<long>
{
    public long Id {  get; set; }
    
    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Phone { get; set; }
}
