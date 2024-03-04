using MediatR;

namespace ThunderWings.Application.Orders.GetOrder;

public record GetOrderQuery(Guid OrderId) : IRequest<OrderResponse>;
