using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Orders.AddOrderItem;
using ThunderWings.Application.Orders.GetOrder;
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

        var result = await _sender.Send(query, cancellationToken);

        return Ok(result);
    }
    
    [HttpPost]
    [Route("addorderitem")]
    public async Task<IActionResult>  AddOrderItem(AddOrderItemRequest request,
        CancellationToken cancellationToken)
    {
        var command = new AddOrderItemCommand(
            request.OrderId,
            new ProductId(request.ProductId));

        await _sender.Send(command, cancellationToken);

        return Ok();
    }
}
