using MediatR;
using ThunderWings.Domain.Products;

namespace ThunderWings.Application.Orders.AddOrderItem;

public record AddOrderItemCommand(
    Guid? OrderId,
    ProductId ProductId) : IRequest;

public record AddOrderItemRequest(Guid? OrderId, Guid ProductId);
