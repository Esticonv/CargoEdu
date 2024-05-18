using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using R7P.MachineManagerService.Application.Interfaces;
using System.Net.Http.Json;

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

                /*var machineService = serviceProvider.GetRequiredService<IMachineService>();
                var address = configuration.GetSection("ServicesUri").GetValue<string>("OrderService_Orders_GetAll");
                var http = httpClientFactory.CreateClient();
                
                var orders = await http.GetFromJsonAsync<int?>($"{address}")
                    ?? throw new InvalidOperationException("Bad request to CalculationDto");*/
                //get Pending Orders
                //get Machines

                //foreach (var order in orders){
                //create and Add MachineTask
                //}


                await Task.Delay(2000, stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            //Действия при останове сервиса 
            return base.StopAsync(cancellationToken);
        }
    }
}
