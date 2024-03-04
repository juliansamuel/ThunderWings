using ThunderWings.Domain.Products;

namespace ThunderWings.Domain.Orders;

public class OrderItem
{
    internal OrderItem(OrderItemId id, OrderId orderId, ProductId productId, decimal price, DateTime dateCreated)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
        DateCreated = dateCreated;
    }

    private OrderItem()
    {
    }

    public OrderItemId Id { get; private set; }

    public OrderId OrderId { get; private set; }

    public ProductId ProductId { get; private set; }

    public Product Product { get; private set; }

    public decimal Price { get; private set; }

    public DateTime DateCreated { get; private set; }
}