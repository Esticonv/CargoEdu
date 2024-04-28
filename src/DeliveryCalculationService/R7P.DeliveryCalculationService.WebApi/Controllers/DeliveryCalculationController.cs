using Microsoft.AspNetCore.Mvc;
using R7P.DeliveryCalculationService.Application.Dtos;
using R7P.DeliveryCalculationService.Application.Services;
using R7P.DeliveryCalculationService.WebApi.Models;

namespace R7P.DeliveryCalculationService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliveryCalculationController(
    IDeliveryCalculationService deliveryCalculationService, IHttpClientFactory httpClientFactory, IConfiguration configuration) 
    : ControllerBase
{
    private readonly IDeliveryCalculationService _deliveryCalculationService = deliveryCalculationService;
    private readonly IConfiguration _configuration = configuration;

    [HttpGet("{id}")]
    public async Task<CalculationDto> GetCalculationsAsync(long id)
    {
        return await _deliveryCalculationService.GetById(id);  
    }

    [HttpGet("{from}&{to}&{size}")]
    public async Task<CalculationDto[]> GetCalculationsAsync(string from, string to, double size) 
    { 
        var http = httpClientFactory.CreateClient();

        var address = _configuration.GetSection("ServicesUri").GetValue<string>("MachineManagerService_Machine");
        var machines = await http.GetFromJsonAsync<MachineDto[]>(address);
                
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
