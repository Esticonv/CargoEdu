using R7P.OrderService.Infrastructure.Data.Initializer;

namespace R7P.OrderService.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static async Task<WebApplication> UseWebServicesAsync(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapControllers();

        await app.Services.InitialiseDatabaseAsync();

        return app;
    }
}
