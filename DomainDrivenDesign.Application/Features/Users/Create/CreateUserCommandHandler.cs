using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Domain.Users.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Users.Create;

public class CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork,IMediator mediator) : IRequestHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.CreateAsync(
            request.Name,
            request.Email,
            request.Password,
            request.Country,
            request.PostalCode,
            request.FullAddress,
            cancellationToken
        );

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await mediator.Publish(new UserDomainEvent(user));

    }
}