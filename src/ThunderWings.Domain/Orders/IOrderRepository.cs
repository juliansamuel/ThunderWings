namespace ThunderWings.Domain.Orders;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(OrderId id);

    void Add(Order order);

    void Update(Order order);
}