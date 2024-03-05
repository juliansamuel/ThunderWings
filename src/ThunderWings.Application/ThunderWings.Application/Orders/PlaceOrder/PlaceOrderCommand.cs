using MediatR;
using ThunderWings.Application.Orders.GetOrder;
using ThunderWings.Domain.Orders;

namespace ThunderWings.Application.Orders.PlaceOrder;

public record PlaceOrderCommand(OrderId OrderId) : IRequest<OrderResponse>;
