using R7P.OrderService.Domain.Enums;

namespace R7P.OrderService.Domain.Entities;

public class Order : IEntity<long>
{
    public long Id { get; set; }

    public required decimal TotalPrice { get; set; }

    public required OrderStatus Status { get; set;}

    // TODO:: удалить поля Length, Width, Height. добавить Volume
    public required float Length  { get; set; }

    public required float Width { get; set; }

    public required float Height { get; set; }

    public required float Weight { get; set; }

    public required long CustomerId { get; set;}

    public required long DepartureAddressId { get; set; }

    public required long DestinationAddressId { get; set; }
}
