using MediatR;

namespace ThunderWings.Application.Orders.Create;

public record CreateOrderCommand(Guid CustomerId) : IRequest;
