using MediatR;
using Microsoft.AspNetCore.Mvc;
using R7P.OrderService.Application.Features.Orders.Commands.CreateOrder;

namespace R7P.OrderService.WebApi.Controllers;

public class OrderController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;    

    [HttpPost("checkout")]
    public async Task<long> Checkout(CreateOrderCommand request)
    {
        return await _mediator.Send(request);
    }
}
