using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using R7P.MachineManagerService.Application.Dtos;
using R7P.MachineManagerService.Application.Interfaces;
using System.Net.Http.Json;
using System.Linq;
using R7P.SharedModels;
using MassTransit;
using System;

namespace R7P.MachineManagerService.Application.Implementations
{ 
    public class SchedulerService(
        ILogger<SchedulerService> logger, 
        IServiceProvider serviceProvider, 
        IHttpClientFactory httpClientFactory, 
        IConfiguration configuration) 
        : BackgroundService
    {
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Starting {nameof(SchedulerService)}");
            try {
                
            }
            catch (Exception ex) {
                logger.LogError(ex, "Error during start bus");
            }
            cancellationToken.Register(() => logger.LogInformation($"{nameof(SchedulerService)} task is stopping."));
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) {
                if (logger.IsEnabled(LogLevel.Information)) {
                    logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                try {
                    //var machineService = serviceProvider.GetRequiredService<IMachineService>();
                    var machineTaskService = serviceProvider.GetRequiredService<IMachineTaskService>();
                    var publishEndpoint = serviceProvider.GetRequiredService<IPublishEndpoint>();

                    var address = configuration.GetSection("ServicesUri").GetValue<string>("OrderService_Order");
                    var http = httpClientFactory.CreateClient();
                    var orders = await http.GetFromJsonAsync<OrderDto[]?>($"{address}/getAll")
                        ?? throw new InvalidOperationException("Bad request to CalculationDto");
                    var pendingOrders = orders.Where(x => x.Status == OrderStatus.Pending);

                    foreach (var pendingOrder in pendingOrders) {
                        var machineTaskDto = new Models.MachineTaskDto() {
                            MachineId = pendingOrder.MachineId,
                            Departure = pendingOrder.DepartureAddress,
                            Destination = pendingOrder.DestinationAddress,
                            TaskType = 1
                        };
                        await machineTaskService.AddAsync(machineTaskDto);

                        await publishEndpoint.Publish(
                            new UpdateOrder() {
                                OrderId = pendingOrder.Id,
                                Status = (int)OrderStatus.Processing
                            });
                    }
                }
                catch (Exception ex) {
                    logger.LogError(ex.Message);
                }

                await Task.Delay(10000, stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            //Действия при останове сервиса 
            return base.StopAsync(cancellationToken);
        }
    }
}
