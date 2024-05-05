using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R7P.DeliveryCalculationService.Domain.Entities;
using System.Reflection.Emit;

namespace R7P.DeliveryCalculationService.Infrastructure.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address", "dbo");

        builder.HasKey(x => x.Id);
        builder.HasAlternateKey(x => x.AddressInfo);
    }
}
