using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.ProductRoles.Get;

namespace ThunderWings.Api.Controllers;

[ApiController]
[Route("api/product-roles")]
public class ProductRolesController : ControllerBase
{
    private readonly ISender _sender;

    public ProductRolesController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProductRoles(CancellationToken cancellationToken)
    {
        var query = new GetProductRolesQuery();
        var products = await _sender.Send(query, cancellationToken);
        return Ok(products);
    }
}
