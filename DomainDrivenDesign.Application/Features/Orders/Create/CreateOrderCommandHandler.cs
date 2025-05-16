using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Orders.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Orders.Create;

public class CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork,IMediator mediator) : IRequestHandler<CreateOrderCommand>
{
    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.CreateAsync(request.createOrderDtos, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await mediator.Publish(new OrderDomainEvent(order));
    }
}

