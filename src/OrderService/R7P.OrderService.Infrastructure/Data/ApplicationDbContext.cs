using Microsoft.EntityFrameworkCore;
using R7P.OrderService.Domain.Entities;
using System.Reflection;

namespace R7P.OrderService.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Address> Addresses => Set<Address>();

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Order> Orders => Set<Order>();

    // TODO:: добавить конфигурации, сконфигурировать внешние ключи
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
