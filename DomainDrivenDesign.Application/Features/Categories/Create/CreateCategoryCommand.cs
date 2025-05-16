using MediatR;

namespace DomainDrivenDesign.Application.Features.Categories.Create;

public sealed record CreateCategoryCommand(string Name) : IRequest;

