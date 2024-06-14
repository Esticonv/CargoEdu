using Microsoft.Extensions.DependencyInjection;

namespace R7P.OrderService.Infrastructure.Data.Initializer;

public static class InitializerExtensions
{
    public static async Task InitialiseDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
        await initialiser.InitializeAsync();
        await initialiser.SeedAsync();
    }
}
