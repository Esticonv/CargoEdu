using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R7P.DeliveryCalculationService.Domain.Entities;
using System.Reflection.Emit;

namespace R7P.DeliveryCalculationService.Infrastructure.Configurations;

public class CalculationConfiguration : IEntityTypeConfiguration<Calculation>
{
    public void Configure(EntityTypeBuilder<Calculation> builder)
    {
        builder.ToTable("Calculations", "dbo");
        builder.HasKey(x => x.Id);
    }
}
