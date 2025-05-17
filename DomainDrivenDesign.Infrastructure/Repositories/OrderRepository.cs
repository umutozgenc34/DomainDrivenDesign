using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
    {
        Order order = new(
          Guid.NewGuid(),
          "1",
          DateTime.Now,
          OrderStatusEnum.AwaitingAproval);

        order.CreateOrder(createOrderDtos);

        await context.Orders.AddAsync(order, cancellationToken);
        return order;
    }

    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Orders
            .Include(p => p.OrderLines)
            .ThenInclude(p => p.Product)
            .ToListAsync(cancellationToken);

    }
}
