using DomainDrivenDesign.Domain.Categories;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Categories.GetAll;

public sealed record GetAllCategoriesQuery : IRequest<List<Category>>; // TODO: dto kullan

