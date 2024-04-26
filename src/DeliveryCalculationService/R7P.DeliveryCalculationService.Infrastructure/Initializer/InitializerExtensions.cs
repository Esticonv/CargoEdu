using Microsoft.Extensions.DependencyInjection;

namespace R7P.DeliveryCalculationService.Infrastructure.Initialiser;

public static class InitializerExtensions
{
    public static async Task InitialiseDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}
