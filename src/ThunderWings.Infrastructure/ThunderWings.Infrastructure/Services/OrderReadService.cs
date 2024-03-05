using Microsoft.EntityFrameworkCore;
using ThunderWings.Application.Orders;
using ThunderWings.Application.Orders.GetOrder;
using ThunderWings.Domain.Orders;

namespace ThunderWings.Infrastructure.Services;

internal sealed class OrderReadService : IOrderReadService
{
    private readonly ApplicationDbContext _context;

    public OrderReadService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderResponse?> GetByIdAsync(OrderId id)
    {
        var orderResponse = await _context
            .Orders
            .Where(o => o.Id == id)
            .Select(o => new OrderResponse(
                o.Id.Value,
                o.DateCreated,
                o.DatePlaced,
                o.OrderItems.Sum(oi => oi.Price),
                o.OrderItems
                    .Select(oi => new OrderItemResponse(
                        oi.Id.Value, 
                        oi.Product.Name, 
                        oi.Price,
                        1,
                        oi.DateCreated))
                    .ToList()))
            .FirstOrDefaultAsync();

        return orderResponse;
    }
}
