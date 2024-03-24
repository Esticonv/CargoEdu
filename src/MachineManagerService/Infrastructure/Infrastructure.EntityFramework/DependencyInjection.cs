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
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<ApplicationDbContextInitialiser>();

            return services;
        }

        public static void InitialiseDatabaseAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
            initialiser.Initialise();
            //await initialiser.SeedAsync();
        }
    }
}