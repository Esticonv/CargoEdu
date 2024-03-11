using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using R7P.MachineManagerService.Infrastructure.EntityFramework;


namespace R7P.MachineManagerService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>((sp, options) =>
            {
                options.UseNpgsql(connectionString);
            });

            //services.AddScoped<ApplicationDbContextInitialiser>();

            return services;
        }
    }
}