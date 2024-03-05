using MediatR;
using ThunderWings.Domain.Products;

namespace ThunderWings.Application.Orders.AddOrderItem;

public record AddOrderItemCommand(
    Guid? OrderId,
    ProductId ProductId) : IRequest<AddOrderItemResponse>;

public record AddOrderItemRequest(Guid? OrderId, Guid ProductId) : IRequest<AddOrderItemResponse>;
