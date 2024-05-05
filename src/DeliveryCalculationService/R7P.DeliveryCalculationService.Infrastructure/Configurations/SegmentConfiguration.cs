using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R7P.DeliveryCalculationService.Domain.Entities;
using System.Reflection.Emit;

namespace R7P.DeliveryCalculationService.Infrastructure.Configurations;

public class SegmentConfiguration : IEntityTypeConfiguration<Segment>
{
    public void Configure(EntityTypeBuilder<Segment> builder)
    {
        builder.ToTable("Segments", "dbo");

        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.DepartureAddress).WithMany();
        builder.HasOne(x => x.DestinationAddress).WithMany();
        builder.HasAlternateKey(x => new { x.DepartureAddressId, x.DestinationAddressId });
    }
}
