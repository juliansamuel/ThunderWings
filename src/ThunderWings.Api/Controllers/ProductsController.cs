using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Products.Get;

namespace ThunderWings.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        var query = new GetProductsQuery();

        var products = await _sender.Send(query, cancellationToken);

        return Ok(products);
    }
}
