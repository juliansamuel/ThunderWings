using MediatR;
using ThunderWings.Domain.Orders;

namespace ThunderWings.Application.Orders.RemoveOrderItem;

internal sealed class RemoveOrderItemCommandHandler : IRequestHandler<RemoveOrderItemCommand>
{
    private readonly IOrderRepository _orderRepository;

    public RemoveOrderItemCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);

        if (order is null)
        {
            throw new OrderNotFoundException(request.OrderId);
        }

        order.RemoveOrderItem(request.OrderItemId);
    }
}
