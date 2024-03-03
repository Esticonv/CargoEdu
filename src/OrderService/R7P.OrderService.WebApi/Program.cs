using R7P.OrderService.WebApi;
using R7P.OrderService.Infrastructure;
using R7P.OrderService.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

await app.UseWebServicesAsync();

app.Run();
