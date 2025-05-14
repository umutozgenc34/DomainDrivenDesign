﻿namespace DomainDrivenDesign.Domain.Orders;

public enum OrderStatusEnum
{
    AwaitingAproval = 1,
    BeingPrepared = 2,
    InTransit = 3,
    Delivered = 4
}