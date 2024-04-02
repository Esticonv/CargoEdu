using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R7P.OrderService.Infrastructure.Data.Initialiser;
using R7P.OrderService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using R7P.OrderService.Infrastructure.Data.Repositories;
using R7P.OrderService.Application.Repositories;
using MassTransit;
using R7P.OrderService.Infrastructure.Options;

namespace R7P.OrderService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        RabbitMqSettings? rabbitMqSettings = configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
        if (rabbitMqSettings == null)
        {
            throw new NullReferenceException("Отстутствуют настройки RabbitMq.");
        }

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqSettings.Host, x =>
                {
                    x.Username(rabbitMqSettings.Login);
                    x.Password(rabbitMqSettings.Password);
                });

            });
        });

        return services;
    }
}