using R7P.OrderService.WebApi;
using R7P.OrderService.Infrastructure;
using R7P.OrderService.Application;
using MassTransit;
using R7P.OrderService.WebApi.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

builder.Services.AddHttpClient();

var rabbitMQHost = builder.Configuration.GetSection("ServicesUri").GetValue<string>("RabbitMQ");
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateOrderConsumer>();
    x.AddConsumer<UpdateOrderConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitMQHost, "/", h => {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ConfigureEndpoints(context);
    });
});


var app = builder.Build();

await app.UseWebServicesAsync();

app.Run();
