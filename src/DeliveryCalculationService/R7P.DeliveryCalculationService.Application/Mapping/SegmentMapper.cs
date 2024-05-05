using Riok.Mapperly.Abstractions;

namespace R7P.DeliveryCalculationService.Application.Mapping
{
    [Mapper]
    public static partial class SegmentMapper
    {
        public static partial Dtos.SegmentDto ToDto(Domain.Entities.Segment segment);
        public static partial Domain.Entities.Segment ToDomain(Dtos.SegmentDto segmentDto);
    }
}
