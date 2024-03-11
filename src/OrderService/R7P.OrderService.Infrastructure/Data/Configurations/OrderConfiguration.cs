using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders", "dbo");

        builder.Property(c => c.Id)    
            .HasColumnName("Id")    
            .ValueGeneratedOnAdd();

        builder.HasOne(x => x.Customer)    
            .WithMany(x => x.Orders)    
            .HasForeignKey(x => x.CustomerId)    
            .IsRequired();

        builder.HasOne(x => x.DepartureAddress)
            .WithMany()
            .HasForeignKey(x => x.DepartureAddressId)
            .IsRequired();

        builder.HasOne(x => x.DestinationAddress)
            .WithMany()
            .HasForeignKey(x => x.DestinationAddressId)
            .IsRequired();
    }
}
