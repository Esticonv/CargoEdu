using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R7P.OrderService.Infrastructure.Data.Initializer;
using R7P.OrderService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using R7P.OrderService.Infrastructure.Data.Repositories;
using R7P.OrderService.Application.Repositories;

namespace R7P.OrderService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<ApplicationDbContextInitializer>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}