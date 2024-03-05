using ThunderWings.Domain.Products;

namespace ThunderWings.Domain.Orders;

public class Order
{
    private readonly List<OrderItem> _orderItems = new();

    private Order()
    {
    }

    public OrderId Id { get; private set; }

    public DateTime DateCreated { get; private set; }

    public DateTime? DatePlaced { get; private set; }

    public IReadOnlyList<OrderItem> OrderItems => _orderItems.ToList();

    public static Order Create()
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            DateCreated = DateTime.UtcNow
        };
        return order;
    }

    public void AddOrderItem(ProductId productId, decimal price)
    {
        var orderItem = new OrderItem(
            new OrderItemId(Guid.NewGuid()),
            Id,
            productId,
            price,
            DateTime.UtcNow);

        _orderItems.Add(orderItem);
    }

    public void RemoveOrderItem(OrderItemId orderItemId)
    {
        var orderItem = _orderItems.FirstOrDefault(oi => oi.Id == orderItemId);
        if (orderItem is null)
        {
            throw new OrderItemNotFoundException(orderItemId);
        }
        _orderItems.Remove(orderItem);
    }

    public void PlaceOrder()
    {
        DatePlaced = DateTime.UtcNow;
    }
}