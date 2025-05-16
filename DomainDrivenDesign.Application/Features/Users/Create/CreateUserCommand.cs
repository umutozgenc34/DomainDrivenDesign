using MediatR;

namespace DomainDrivenDesign.Application.Features.Users.Create;

public sealed record CreateUserCommand(string Name, string Email, string Password, string Country, string PostalCode, string FullAddress) : IRequest;
