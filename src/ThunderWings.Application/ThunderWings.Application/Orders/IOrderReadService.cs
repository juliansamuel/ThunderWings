using ThunderWings.Application.Orders.GetOrder;
using ThunderWings.Domain.Orders;

namespace ThunderWings.Application.Orders;

public interface IOrderReadService
{
    Task<OrderResponse?> GetByIdAsync(OrderId id);
}
