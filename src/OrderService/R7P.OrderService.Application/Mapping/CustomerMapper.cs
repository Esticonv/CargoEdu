using Riok.Mapperly.Abstractions;

namespace R7P.OrderService.Application.Mapping
{
    [Mapper]
    public static partial class CustomerMapper
    {
        public static partial Dtos.CustomerDto ToDto(Domain.Entities.Customer customer);
        public static partial Domain.Entities.Customer ToDomain(Dtos.CustomerDto customerDto);
    }
}
