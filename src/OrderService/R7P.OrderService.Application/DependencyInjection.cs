﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R7P.OrderService.Application.Services;

namespace R7P.OrderService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAddressService, AddressService>();

        return services;
    }
}
