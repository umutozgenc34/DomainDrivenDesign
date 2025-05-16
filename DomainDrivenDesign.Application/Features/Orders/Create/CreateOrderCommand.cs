using DomainDrivenDesign.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders.Create;

public sealed record CreateOrderCommand(List<CreateOrderDto> createOrderDtos) : IRequest;

