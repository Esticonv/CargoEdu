namespace R7P.OrderService.Application.Dtos
{
    public class CustomerDto
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

        public ICollection<OrderDto> Orders { get; set; } = null!;

    }
}
