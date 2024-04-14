using MediatR;
using R7P.Infrastructure.Core.Repositories;
using R7P.OrderService.Application.Repositories;
using R7P.OrderService.Domain.Entities;

namespace R7P.OrderService.Infrastructure.Data.Repositories;

public class CustomerRepository(ApplicationDbContext context, IMediator mediator) 
    : Repository<Customer, long>(context, mediator), ICustomerRepository
{
}
