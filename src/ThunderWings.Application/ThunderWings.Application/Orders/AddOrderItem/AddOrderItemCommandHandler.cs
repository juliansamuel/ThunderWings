using MediatR;
using ThunderWings.Domain.Orders;
using ThunderWings.Domain.Products;

namespace ThunderWings.Application.Orders.AddOrderItem;

internal sealed class AddOrderItemCommandHandler : IRequestHandler<AddOrderItemCommand, AddOrderItemResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public AddOrderItemCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<AddOrderItemResponse> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
    {
        Order order;
        if (request.OrderId is null)
        {
            order = Order.Create();

            _orderRepository.Add(order);
        }
        else
        {
            var orderId = new OrderId((Guid)request.OrderId);
            order = await _orderRepository.GetByIdAsync(orderId);

            if (order is null)
            {
                throw new OrderNotFoundException(orderId);
            }
        }

        var product = await _productRepository.GetByIdAsync(request.ProductId);
        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        order.AddOrderItem(request.ProductId, product.Price);

        return new AddOrderItemResponse(order.Id.Value);
    }
}
