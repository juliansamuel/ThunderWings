namespace ThunderWings.Application.Orders.GetOrder;

public record OrderResponse(Guid Id, decimal TotalPrice, List<OrderItemResponse> OrderItems);