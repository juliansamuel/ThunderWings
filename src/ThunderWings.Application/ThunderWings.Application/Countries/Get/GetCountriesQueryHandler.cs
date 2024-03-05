using MediatR;
using Microsoft.EntityFrameworkCore;
using ThunderWings.Application.Data;

namespace ThunderWings.Application.Countries.Get;

internal sealed class GetCountriesQueryHandler
    : IRequestHandler<GetCountriesQuery, IReadOnlyList<CountryResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetCountriesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<CountryResponse>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries= await _context
            .Countries
            .Select(p => new CountryResponse(
                p.Id.Value,
                p.Name))
            .ToListAsync(cancellationToken);

        return countries;
    }
}
