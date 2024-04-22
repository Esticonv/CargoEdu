﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R7P.DeliveryCalculationService.Application.Services;

namespace R7P.DeliveryCalculationService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDeliveryCalculationService, Services.DeliveryCalculationService>();

        return services;
    }
}