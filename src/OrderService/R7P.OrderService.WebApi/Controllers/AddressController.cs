using Microsoft.AspNetCore.Mvc;
using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Services;

namespace R7P.OrderService.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController(IAddressService addressService) : ControllerBase
{
    private readonly IAddressService _addressService = addressService;

    [HttpGet("getById/{id}")]
    public async Task<AddressDto> Get(int id)
    {
        return await _addressService.GetById(id);
    }

    [HttpGet("getAll")]
    public async Task<AddressDto[]> GetAll()
    {
        return await _addressService.GetAll();
    }
}
