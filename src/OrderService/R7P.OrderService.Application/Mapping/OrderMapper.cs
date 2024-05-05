using Riok.Mapperly.Abstractions;

namespace R7P.OrderService.Application.Mapping
{
    [Mapper]
    public static partial class OrderMapper
    {
        public static partial Dtos.OrderDto ToDto(Domain.Entities.Order customer);
        public static partial Domain.Entities.Order ToDomain(Dtos.OrderDto customerDto);
    }
}
