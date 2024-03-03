using MediatR;
using Microsoft.EntityFrameworkCore;
using ThunderWings.Application.Data;
using ThunderWings.Application.Products.Shared;

namespace ThunderWings.Application.Products.Get;

internal sealed class GetProductsQueryHandler
    : IRequestHandler<GetProductsQuery, IReadOnlyList<ProductResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetProductsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _context
            .Products
            .Include(p => p.Country)
            .Include(p => p.Manufacturer)
            .Include(p => p.ProductRole)
            .Select(p => new ProductResponse(
                p.Id.Value,
                p.Name,
                p.Country.Name,
                p.Manufacturer.Name,
                p.ProductRole.Name,
                p.TopSpeed,
                p.Price))
            .ToListAsync(cancellationToken);
        return products;
    }
}
