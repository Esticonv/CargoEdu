using R7P.OrderService.Application.Dtos;

namespace R7P.OrderService.Application.Services;

public interface IAddressService
{
    Task<AddressDto> GetById(int id);
}
