using R7P.DeliveryCalculationService.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace R7P.DeliveryCalculationService.Application.Mapping
{
    [Mapper]
    public static partial class AddressMapper
    {
        public static partial Dtos.AddressDto ToDto(Domain.Entities.Address address);
        public static partial Domain.Entities.Address ToDomain(Dtos.AddressDto addressDto);
    }
}
