using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses", "dbo");

        builder.Property(c => c.Id)    
            .HasColumnName("Id")    
            .ValueGeneratedOnAdd();
    }
}
