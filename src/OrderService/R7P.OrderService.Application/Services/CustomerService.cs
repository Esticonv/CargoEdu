using R7P.OrderService.Application.Dtos;
using R7P.OrderService.Application.Repositories;

namespace R7P.OrderService.Application.Services;

public class CustomerService(ICustomerRepository addressRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = addressRepository;

    public async Task<CustomerDto[]> GetAll()
    {
        var customers = await _customerRepository.GetAllAsync(CancellationToken.None);
        var result = customers.Select(x => Mapping.CustomerMapper.ToDto(x)).ToArray();
        return result;
    }

    public async Task<CustomerDto> GetById(long id)
    {
        var customer = await _customerRepository.GetAsync(id)
            ?? throw new ArgumentException($"Не найден адрес с идентифкатором {id}");

        return Mapping.CustomerMapper.ToDto(customer);
    }
}
