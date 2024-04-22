using Microsoft.EntityFrameworkCore;
using R7P.DeliveryCalculationService.Domain.Entities;
using System.Reflection;

namespace R7P.DeliveryCalculationService.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Segment> Segments => Set<Segment>();
    public DbSet<Address> AddressSpecs => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<DeliverySpecification>().HasKey(k => k.DepartureAddressId);
        //modelBuilder.Entity<DeliverySpecification>().HasKey(k => k.DestinationAddressId);

        modelBuilder.Entity<Segment>().HasKey(x => x.Id);
        modelBuilder.Entity<Segment>().HasOne(x => x.DepartureAddress).WithMany();
        modelBuilder.Entity<Segment>().HasOne(x => x.DestinationAddress).WithMany();

        modelBuilder.Entity<Address>().HasKey(x => x.Id);
    }
}