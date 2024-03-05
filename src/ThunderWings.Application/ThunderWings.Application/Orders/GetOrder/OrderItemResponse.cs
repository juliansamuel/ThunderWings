namespace ThunderWings.Application.Orders.GetOrder;

public record OrderItemResponse(Guid Id, string ProductName, decimal Price, int Quantity, DateTime DateCreated1);