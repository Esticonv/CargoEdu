using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R7P.DeliveryCalculationService.Domain.Entities;

namespace R7P.DeliveryCalculationService.Infrastructure.Configurations;

public class DeliverySpecificationConfiguration : IEntityTypeConfiguration<DeliverySpecification>
{
    public void Configure(EntityTypeBuilder<DeliverySpecification> builder)
    {
        builder.ToTable("DeliverySpecifications", "dbo");

        builder.Property(c => c.Id)    
            .HasColumnName("Id")    
            .ValueGeneratedOnAdd();
    }
}
