using MediatR;
using ThunderWings.Application.Data;
using ThunderWings.Application.Orders.GetOrder;
using ThunderWings.Domain.Orders;

namespace ThunderWings.Application.Orders.PlaceOrder;

internal sealed class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, OrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderReadService _orderReadService;
    private readonly IUnitOfWork _unitOfWork;

    public PlaceOrderCommandHandler(IOrderRepository orderRepository, IOrderReadService orderReadService, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _orderReadService = orderReadService;
        _unitOfWork = unitOfWork;
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

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return await _orderReadService.GetByIdAsync(order.Id);
    }
}
