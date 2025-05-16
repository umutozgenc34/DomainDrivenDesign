using DomainDrivenDesign.Domain.Orders;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders.GetAll;

public sealed record GetAllOrdersQuery() : IRequest<List<Order>>; //TODO: dto kullan


