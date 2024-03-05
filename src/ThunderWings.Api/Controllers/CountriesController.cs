using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Countries.Get;

namespace ThunderWings.Api.Controllers;

[ApiController]
[Route("api/countries")]
public class CountriesController : ControllerBase
{
    private readonly ISender _sender;

    public CountriesController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCountries(CancellationToken cancellationToken)
    {
        var query = new GetCountriesQuery();
        var products = await _sender.Send(query, cancellationToken);
        return Ok(products);
    }
}
