namespace ThunderWings.Application.Orders.GetOrder;

public record OrderResponse(Guid Id, DateTime DateCreated, DateTime? DatePlaced, decimal TotalPrice, List<OrderItemResponse> OrderItems);