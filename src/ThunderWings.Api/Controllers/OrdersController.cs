using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Orders.AddOrderItem;
using ThunderWings.Application.Orders.GetOrder;
using ThunderWings.Application.Orders.PlaceOrder;
using ThunderWings.Application.Orders.RemoveOrderItem;
using ThunderWings.Domain.Orders;
using ThunderWings.Domain.Products;

namespace ThunderWings.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;

    public OrdersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetOrderQuery(id);

        var result= await _sender.Send(query, cancellationToken);

        return Ok(result);
    }
    
    [HttpPost("add-order-item")]
    public async Task<IActionResult> AddOrderItem(AddOrderItemRequest request, CancellationToken cancellationToken)
    {
        var command = new AddOrderItemCommand(request.OrderId, new ProductId(request.ProductId));

        var result = await _sender.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id}/order-items/{orderItemId}")]
    public async Task<IActionResult> RemoveOrderItem(Guid id, Guid orderItemId, CancellationToken cancellationToken)
    {
        var command = new RemoveOrderItemCommand(new OrderId(id), new OrderItemId(orderItemId));

        await _sender.Send(command, cancellationToken);

        return Ok();
    }

    [HttpPut("{id}/place-order")]
    public async Task<IActionResult> PlaceOrder(Guid id, CancellationToken cancellationToken)
    {
        var command = new PlaceOrderCommand(new OrderId(id));

        var result = await _sender.Send(command, cancellationToken);

        return Ok(result);
    }
}
