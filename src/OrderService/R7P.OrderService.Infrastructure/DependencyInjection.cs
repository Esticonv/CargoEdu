using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R7P.OrderService.Infrastructure.Data.Initialiser;
using R7P.OrderService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        services.AddScoped<ApplicationDbContextInitialiser>();

        return services;
    }
}