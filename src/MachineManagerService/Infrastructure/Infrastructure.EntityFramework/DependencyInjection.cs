using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace R7P.MachineManagerService.Infrastructure.EntityFramework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureEFServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options
                .UseLazyLoadingProxies()
                .UseNpgsql(connectionString);
            });
           
            services.AddScoped<ApplicationDbContextInitializer>();

            return services;
        }

        public static void InitializeDatabaseAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
            initializer.Initialize();
            initializer.Seed();
        }
    }
}