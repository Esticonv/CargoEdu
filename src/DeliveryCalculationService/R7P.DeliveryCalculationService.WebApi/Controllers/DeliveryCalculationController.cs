using Microsoft.AspNetCore.Mvc;
using R7P.DeliveryCalculationService.Application.Dtos;
using R7P.DeliveryCalculationService.Application.Services;
using R7P.DeliveryCalculationService.WebApi.Models;

namespace R7P.DeliveryCalculationService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliveryCalculationController(IDeliveryCalculationService deliveryCalculationService, IHttpClientFactory httpClientFactory) : ControllerBase
{
    private readonly IDeliveryCalculationService _deliveryCalculationService = deliveryCalculationService;

    [HttpGet("{id}")]
    public async Task<CalculationDto> GetCalculationsAsync(long id)
    {
        return await _deliveryCalculationService.GetById(id);  
    }

    [HttpGet("{from}&{to}&{size}")]
    public async Task<CalculationDto[]> GetCalculationsAsync(string from, string to, double size) 
    { 
        var http = httpClientFactory.CreateClient();
        var machines = await http.GetFromJsonAsync<MachineDto[]>("http://r7p.machinemanagerservice.webapi:8080/machine");
                
        var path = await _deliveryCalculationService.GetDistance(from, to);
        if (double.IsNaN(path.Distance)) {
            throw new ArgumentException($"Path not found from:{from} to:{to}");
        }

        var calculations=new List<CalculationDto>();
        foreach(var machine in machines) {
            var calculation=new CalculationDto() {
                DeliveryTime = TimeSpan.FromSeconds(path.Distance/machine.MaxSpeed), 
                Cost = (decimal)path.Distance * machine.CostPerDistance,
                DepartureAddressId = path.DepartureAddressId,
                DestinationAddressId = path.DestinationAddressId,
                MachineId = machine.Id,
                CargoSize = size,
            };
            calculations.Add(calculation);
        }

        var arrCalculations = calculations.ToArray();
        arrCalculations = await _deliveryCalculationService.SaveCalculation(arrCalculations);

        foreach(var calculation in arrCalculations) {
            calculation.DepartureAddress = path.DepartureAddress;
            calculation.DestinationAddress = path.DestinationAddress;
        }

        return arrCalculations;
    }
}
