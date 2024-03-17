using Microsoft.EntityFrameworkCore;
using R7P.DeliveryCalculationService.Domain.Entities;

namespace R7P.DeliveryCalculationService.Infrastructure;

public class DatabaseContext : DbContext
{
    public DbSet<DeliverySpecification> DeliverySpecifications { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DeliverySpecification>().HasKey(k => k.DepartureAddressId);
        modelBuilder.Entity<DeliverySpecification>().HasKey(k => k.DestinationAddressId);
    }
}