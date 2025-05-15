﻿using MediatR;

namespace DomainDrivenDesign.Domain.Orders.Events;

public sealed class SendOrderSmsEvent : INotificationHandler<OrderDomainEvent>
{
    public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
    {
        // Logic to send sms
        return Task.CompletedTask;
    }
}
