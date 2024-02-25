namespace R7P.OrderService.Domain.Entities;

public class Tariff : IEntityBase
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public required decimal Price { get; set; }

    public required DateTime DeliveryTime { get; set;}
}
