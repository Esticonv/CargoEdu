using Microsoft.AspNetCore.Mvc;
using R7P.DeliveryCalculationService.Application.Dtos;
using R7P.DeliveryCalculationService.Application.Services;

namespace R7P.DeliveryCalculationService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeliverySpecificationController(IDeliveryCalculationService deliveryCalculationService) : ControllerBase
{
    private readonly IDeliveryCalculationService _deliveryCalculationService = deliveryCalculationService;

    [HttpGet("getById/{id}")]
    public async Task<DeliverySpecificationDto> Get(int id)
    {
        return await _deliveryCalculationService.GetById(id);
    }

    [HttpGet("getAll")]
    public async Task<DeliverySpecificationDto[]> GetAll()
    {
        return await _deliveryCalculationService.GetAll();
    }
}
