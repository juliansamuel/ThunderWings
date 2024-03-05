namespace ThunderWings.Domain.Orders;

public sealed class OrderItemNotFoundException : Exception
{
    public OrderItemNotFoundException(OrderItemId id)
        : base($"The order item with the ID = {id.Value} was not found")
    {
    }
}
