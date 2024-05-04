using MassTransit;
using R7P.DeliveryCalculationService.Application.Dtos;
using R7P.DeliveryCalculationService.Application.Services;
using R7P.DeliveryCalculationService.WebApi.Models;
using R7P.SharedModels;

internal class CalculateCostConsumer(
    ILogger<CalculateCostConsumer> logger, 
    IDeliveryCalculationService deliveryCalculationService,
    IHttpClientFactory httpClientFactory, 
    IConfiguration configuration) 
    : IConsumer<CalculateCost>
{
    public async Task Consume(ConsumeContext<CalculateCost> context)
    {
        logger.LogInformation($"Consume {context.Message}");

        var calculateCostRequest = context.Message;

        var http = httpClientFactory.CreateClient();

        var address = configuration.GetSection("ServicesUri").GetValue<string>("MachineManagerService_Machine");
        var machines = await http.GetFromJsonAsync<MachineDto[]>(address) ?? throw new InvalidOperationException("Bad request for MachineDto");

        var path = await deliveryCalculationService.GetDistance(calculateCostRequest.From, calculateCostRequest.To);
        if (double.IsNaN(path.Distance)) {
            throw new ArgumentException($"Path not found from:{calculateCostRequest.From} to:{calculateCostRequest.To}");
        }

        var calculations = new List<CalculationDto>();
        foreach (var machine in machines) {
            var calculation = new CalculationDto() {
                DeliveryTime = TimeSpan.FromSeconds(path.Distance / machine.MaxSpeed),
                Cost = (decimal)path.Distance * machine.CostPerDistance,
                DepartureAddressId = path.DepartureAddressId,
                DestinationAddressId = path.DestinationAddressId,
                MachineId = machine.Id,
                CargoSize = calculateCostRequest.Size,
            };
            calculations.Add(calculation);
        }

        var arrCalculations = calculations.ToArray();
        arrCalculations = await deliveryCalculationService.SaveCalculation(arrCalculations);

        var calculateCostResult = 
            new CalculateCostResult{
                Calculations = [..arrCalculations.Select(x => {
                                    return new OneCalculateCost { Id = x.Id, Cost = x.Cost, DeliveryTime = x.DeliveryTime }; 
                                    })]};

        await context.RespondAsync(calculateCostResult);
    }
}