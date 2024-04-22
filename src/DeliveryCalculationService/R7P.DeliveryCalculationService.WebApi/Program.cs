using R7P.DeliveryCalculationService.WebApi;
using R7P.DeliveryCalculationService.Infrastructure;
using R7P.DeliveryCalculationService.Application;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

builder.Services.AddHttpClient();


var app = builder.Build();

//if (app.Environment.IsDevelopment()) {
app.UseSwagger();
app.UseSwaggerUI();
//}


await app.UseWebServicesAsync();

app.Run();
