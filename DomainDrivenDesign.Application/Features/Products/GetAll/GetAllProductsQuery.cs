using DomainDrivenDesign.Domain.Products;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Products.GetAll;

public sealed record GetAllProductsQuery() : IRequest<List<Product>>;  //TODO: dto kullan
