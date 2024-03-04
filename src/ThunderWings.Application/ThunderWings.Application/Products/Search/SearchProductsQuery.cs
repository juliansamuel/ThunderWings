using MediatR;
using ThunderWings.Application.Products.Shared;

namespace ThunderWings.Application.Products.Search;

public record SearchProductsQuery(
    string? ProductName,
    Guid? CountryId,
    Guid? ManufacturerId,
    Guid? ProductRoleId,
    decimal? TopSpeed,
    decimal? Price,
    int Page,
    int PageSize) : IRequest<PagedList<ProductResponse>>;
