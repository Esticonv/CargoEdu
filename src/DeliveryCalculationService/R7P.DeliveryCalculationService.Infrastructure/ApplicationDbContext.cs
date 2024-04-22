using Microsoft.EntityFrameworkCore;
using R7P.DeliveryCalculationService.Domain.Entities;
using System.Reflection;

namespace R7P.DeliveryCalculationService.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<DeliverySpecification> DeliverySpecifications => Set<DeliverySpecification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DeliverySpecification>().HasKey(k => k.DepartureAddressId);
        modelBuilder.Entity<DeliverySpecification>().HasKey(k => k.DestinationAddressId);
    }
}