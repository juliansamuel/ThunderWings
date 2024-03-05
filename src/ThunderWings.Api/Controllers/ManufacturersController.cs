using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Manufacturers.Get;

namespace ThunderWings.Api.Controllers;

[ApiController]
[Route("api/manufacturers")]
public class ManufacturersController : ControllerBase
{
    private readonly ISender _sender;

    public ManufacturersController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetManufacturers(CancellationToken cancellationToken)
    {
        var query = new GetManufacturersQuery();
        var products = await _sender.Send(query, cancellationToken);
        return Ok(products);
    }
}
