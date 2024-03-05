using MediatR;
using ThunderWings.Application.Orders.GetOrder;
using ThunderWings.Domain.Orders;

namespace ThunderWings.Application.Orders.PlaceOrder;

internal sealed class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, OrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderReadService _orderReadService;

    public PlaceOrderCommandHandler(IOrderRepository orderRepository, IOrderReadService orderReadService)
    {
        _orderRepository = orderRepository;
        _orderReadService = orderReadService;
    }

    public async Task<OrderResponse?> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);

        if (order is null)
        {
            throw new OrderNotFoundException(request.OrderId);
        }

        order.PlaceOrder();
        _orderRepository.Update(order);

        return await _orderReadService.GetByIdAsync(order.Id);
    }
}
