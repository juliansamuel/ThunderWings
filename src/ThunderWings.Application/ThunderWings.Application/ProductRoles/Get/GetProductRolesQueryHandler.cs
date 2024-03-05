using MediatR;
using Microsoft.EntityFrameworkCore;
using ThunderWings.Application.Data;

namespace ThunderWings.Application.ProductRoles.Get;

internal sealed class GetProductRolesQueryHandler
    : IRequestHandler<GetProductRolesQuery, IReadOnlyList<ProductRoleResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetProductRolesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductRoleResponse>> Handle(GetProductRolesQuery request, CancellationToken cancellationToken)
    {
        var productRoles= await _context
            .ProductRoles
            .Select(p => new ProductRoleResponse(
                p.Id.Value,
                p.Name))
            .ToListAsync(cancellationToken);

        return productRoles;
    }
}