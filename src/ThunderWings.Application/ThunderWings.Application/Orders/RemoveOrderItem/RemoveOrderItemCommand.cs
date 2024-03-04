using MediatR;
using ThunderWings.Domain.Orders;

namespace ThunderWings.Application.Orders.RemoveOrderItem;

public record RemoveOrderItemCommand(OrderId OrderId, OrderItemId OrderItemId) : IRequest;
