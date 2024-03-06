using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Repositories;

namespace R7P.OrderService.Application.Services;

public class AddressService(IAddressRepository addressRepository) : IAddressService
{
    private readonly IAddressRepository _addressRepository = addressRepository;

    public async Task<AddressDto> GetById(int id)
    {
        var address = await _addressRepository.GetAsync(id)
            ?? throw new Exception($"Не найден адрес с идентифкатором {id}");

        return new AddressDto
        {
            Id = address.Id,
            AddressInfo = address.AddressInfo,
            Email = address.Email,
            FirstName = address.FirstName,
            LastName = address.LastName,
            PhoneNumber = address.PhoneNumber,
        };
    }
}
