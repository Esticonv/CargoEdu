using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R7P.DeliveryCalculationService.Infrastructure.Initializer;
using Microsoft.EntityFrameworkCore;
using R7P.DeliveryCalculationService.Infrastructure.Repositories;
using R7P.DeliveryCalculationService.Application.Repositories;

namespace R7P.DeliveryCalculationService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString).UseLazyLoadingProxies();
        });

        services.AddScoped<ApplicationDbContextInitializer>();

        services.AddScoped<ISegmentRepository, SegmentRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICalculationRepository, CalculationRepository>();

        return services;
    }
}