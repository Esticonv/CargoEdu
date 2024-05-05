using R7P.DeliveryCalculationService.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace R7P.DeliveryCalculationService.Application.Mapping
{
    [Mapper]
    public static partial class CalculationMapper
    {
        public static partial Dtos.CalculationDto ToDto(Calculation calculation);
        public static partial Calculation ToDomain(Dtos.CalculationDto calculationDto);
    }
}
