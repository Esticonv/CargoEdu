using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R7P.MachineManagerService.Application.Implementations;
using R7P.MachineManagerService.Application.Interfaces;

namespace R7P.MachineManagerService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {        
        services.AddScoped<IMachineService, MachineService>();

        return services;
    }
}
