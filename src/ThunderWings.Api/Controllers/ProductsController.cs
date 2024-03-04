using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Products.Get;
using ThunderWings.Application.Products.Search;

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

    [HttpGet]
    [Route("search")]
    public async Task<IActionResult> SearchProducts(
        string? name,
        Guid? countryId,
        Guid? manufacturerId,
        Guid? productRoleId,
        decimal? topSpeed,
        decimal? price,
        int page,
        int pageSize,
        CancellationToken cancellationToken)
    {
        var query = new SearchProductsQuery(name, countryId, manufacturerId, productRoleId, topSpeed, price, page, pageSize);
        var products = await _sender.Send(query, cancellationToken);
        return Ok(products);
    }
}
