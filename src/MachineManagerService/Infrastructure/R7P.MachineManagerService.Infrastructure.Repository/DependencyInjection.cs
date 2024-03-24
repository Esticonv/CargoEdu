using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R7P.MachineManagerService.Application.Interfaces;


namespace R7P.MachineManagerService.Infrastructure.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMachineRepository, MachineRepository>();

            return services;
        }
    }
}