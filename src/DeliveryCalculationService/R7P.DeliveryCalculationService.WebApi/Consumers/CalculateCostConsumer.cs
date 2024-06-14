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
        var machinesArr = machines.Where(x => x.Capacity >= context.Message.Size).ToArray();

        var path = await deliveryCalculationService.GetDistanceAsync(calculateCostRequest.From, calculateCostRequest.To);
        var pathDistance = path.Sum(x => x.Distance);
        
        if (pathDistance == 0) {
            throw new ArgumentException($"Path not found from:{calculateCostRequest.From} to:{calculateCostRequest.To}");
        }

        var calculations = new List<CalculationDto>();
        foreach (var machine in machinesArr) {
            var estimateTimeToStart = machine.Tasks?.Where(task => task.TaskType==1).Sum(
                 x => deliveryCalculationService.GetDistanceAsync(x.Departure, x.Destination).Result
                .Sum(segment => segment.Distance)) / machine.MaxSpeed;

            var calculation = new CalculationDto() {
                DeliveryTime = TimeSpan.FromSeconds(pathDistance / machine.MaxSpeed),
                EstimateTimeToStart = TimeSpan.FromSeconds(estimateTimeToStart ?? 0),
                Cost = (decimal)pathDistance * machine.CostPerDistance,
                DepartureAddressId = (await deliveryCalculationService.GetAddressAsync(calculateCostRequest.From)).Id,
                DestinationAddressId = (await deliveryCalculationService.GetAddressAsync(calculateCostRequest.To)).Id,
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
                                    return new OneCalculateCost { 
                                        Id = x.Id, 
                                        Cost = x.Cost, 
                                        DeliveryTime = x.DeliveryTime,
                                        EstimateTimeToStart = x.EstimateTimeToStart}; 
                                    })]};

        await context.RespondAsync(calculateCostResult);
    }
}