using MediatR;
using Microsoft.EntityFrameworkCore;
using ThunderWings.Application.Data;
using ThunderWings.Application.Products.Shared;
using ThunderWings.Domain.Countries;
using ThunderWings.Domain.Manufacturers;
using ThunderWings.Domain.ProductRoles;
using ThunderWings.Domain.Products;

namespace ThunderWings.Application.Products.Search;

internal sealed class SearchProductsQueryHandler
    : IRequestHandler<SearchProductsQuery, PagedList<ProductResponse>>
{
    private readonly IApplicationDbContext _context;

    public SearchProductsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PagedList<ProductResponse>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Product> productsQuery = _context.Products;

        if (!string.IsNullOrWhiteSpace(request.ProductName))
        {
            productsQuery = productsQuery.Where(p => p.Name.Contains(request.ProductName));
        }

        if (request.CountryId != null)
        {
            productsQuery = productsQuery.Where(p => p.CountryId == new CountryId((Guid)request.CountryId));
        }

        if (request.ManufacturerId != null)
        {
            productsQuery = productsQuery.Where(p => p.ManufacturerId == new ManufacturerId((Guid)request.ManufacturerId));
        }

        if (request.ProductRoleId != null)
        {
            productsQuery = productsQuery.Where(p => p.ProductRoleId == new ProductRoleId((Guid)request.ProductRoleId));
        }

        if (request.TopSpeed != null)
        {
            productsQuery = productsQuery.Where(p => p.TopSpeed == request.TopSpeed);
        }

        if (request.Price != null)
        {
            productsQuery = productsQuery.Where(p => p.Price == request.Price);
        }

        var productResponsesQuery = productsQuery
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
                p.Price));

        var products = await PagedList<ProductResponse>.CreateAsync(
            productResponsesQuery,
            request.Page,
            request.PageSize);

        return products;
    }
}
