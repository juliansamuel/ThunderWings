using MediatR;
using ThunderWings.Domain.Orders;

namespace ThunderWings.Application.Orders.Create;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(
        IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.Create();

        _orderRepository.Add(order);
    }

    //public async Task Handle2(CreateOrderCommand request, CancellationToken cancellationToken)
    //{
    //    var customer = await _customerRepository.GetByIdAsync(
    //        new CustomerId(request.CustomerId));

    //    if (customer is null)
    //    {
    //        return;
    //    }

    //    var order = Order.Create(customer.Id);

    //    _orderRepository.Add(order);

    //    _orderSummaryRepository.Add(new OrderSummary(order.Id.Value, customer.Id.Value, 0));
    //}
}
