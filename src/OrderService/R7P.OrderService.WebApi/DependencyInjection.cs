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

        return app;
    }
}
