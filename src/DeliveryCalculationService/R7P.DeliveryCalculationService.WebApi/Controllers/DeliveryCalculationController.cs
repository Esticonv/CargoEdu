using Microsoft.AspNetCore.Mvc;
using R7P.DeliveryCalculationService.Application.Dtos;
using R7P.DeliveryCalculationService.Application.Services;
using R7P.DeliveryCalculationService.WebApi.Models;

namespace R7P.DeliveryCalculationService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliveryCalculationController(
    IDeliveryCalculationService deliveryCalculationService) 
    : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<CalculationDto> GetCalculationsAsync(long id)
    {
        return await deliveryCalculationService.GetById(id);  
    }    
}
