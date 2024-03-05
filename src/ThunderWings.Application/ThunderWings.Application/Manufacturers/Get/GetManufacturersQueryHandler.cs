using MediatR;
using Microsoft.EntityFrameworkCore;
using ThunderWings.Application.Data;

namespace ThunderWings.Application.Manufacturers.Get;

internal sealed class GetManufacturersQueryHandler
    : IRequestHandler<GetManufacturersQuery, IReadOnlyList<ManufacturerResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetManufacturersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ManufacturerResponse>> Handle(GetManufacturersQuery request, CancellationToken cancellationToken)
    {
        var manufacturers= await _context
            .Manufacturers
            .Select(p => new ManufacturerResponse(
                p.Id.Value,
                p.Name))
            .ToListAsync(cancellationToken);

        return manufacturers;
    }
}