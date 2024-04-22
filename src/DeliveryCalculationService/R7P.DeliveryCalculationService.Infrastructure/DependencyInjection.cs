using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R7P.DeliveryCalculationService.Infrastructure.Initialiser;
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
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddScoped<ISegmentRepository, SegmentRepository>();

        return services;
    }
}