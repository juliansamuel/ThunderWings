using Microsoft.EntityFrameworkCore;
using ThunderWings.Application.Products;
using ThunderWings.Application.Products.Search;
using ThunderWings.Application.Products.Shared;
using ThunderWings.Domain.Countries;
using ThunderWings.Domain.Manufacturers;
using ThunderWings.Domain.ProductRoles;
using ThunderWings.Domain.Products;

namespace ThunderWings.Infrastructure.Services;

internal sealed class ProductReadService : IProductReadService
{
    private readonly ApplicationDbContext _context;

    public ProductReadService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductResponse>> GetAsync(CancellationToken cancellationToken)
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

    public async Task<PagedList<ProductResponse>> SearchAsync(SearchProductsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Product> productsQuery = _context.Products;

        if (!string.IsNullOrWhiteSpace(request.ProductName))
        {
            productsQuery = productsQuery.Where(p => p.Name.Contains(request.ProductName));
        }

        if (request.CountryId is not null)
        {
            productsQuery = productsQuery.Where(p => p.CountryId == new CountryId((Guid)request.CountryId));
        }

        if (request.ManufacturerId is not null)
        {
            productsQuery = productsQuery.Where(p => p.ManufacturerId == new ManufacturerId((Guid)request.ManufacturerId));
        }

        if (request.ProductRoleId is not null)
        {
            productsQuery = productsQuery.Where(p => p.ProductRoleId == new ProductRoleId((Guid)request.ProductRoleId));
        }

        if (request.TopSpeed is not null)
        {
            productsQuery = productsQuery.Where(p => p.TopSpeed == request.TopSpeed);
        }

        if (request.Price is not null)
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
            request.PageSize, 
            cancellationToken);

        return products;
    }
}
