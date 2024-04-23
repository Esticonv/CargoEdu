using Riok.Mapperly.Abstractions;

namespace R7P.DeliveryCalculationService.Application.Mapping
{
    [Mapper]
    public static partial class CalculationMapper
    {
        public static partial Dtos.CalculationDto ToDto(Domain.Entities.Calculation calculation);
        public static partial Domain.Entities.Calculation ToDomain(Dtos.CalculationDto calculationDto);
    }
}
