using DomainDrivenDesign.Application.Features.Categories.Create;
using DomainDrivenDesign.Application.Features.Categories.GetAll;
using DomainDrivenDesign.Application.Features.Orders.Create;
using DomainDrivenDesign.Application.Features.Orders.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
