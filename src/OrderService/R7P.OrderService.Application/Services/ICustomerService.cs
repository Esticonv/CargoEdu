using R7P.OrderService.Application.Dtos;

namespace R7P.OrderService.Application.Services;

public interface ICustomerService
{
    Task<CustomerDto> GetById(long id);

    Task<CustomerDto[]> GetAll();
}
