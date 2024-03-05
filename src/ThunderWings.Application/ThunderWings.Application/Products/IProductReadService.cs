using ThunderWings.Application.Products.Search;
using ThunderWings.Application.Products.Shared;

namespace ThunderWings.Application.Products;

public interface IProductReadService
{
    Task<IReadOnlyList<ProductResponse>> GetAsync(CancellationToken cancellationToken);

    Task<PagedList<ProductResponse>> SearchAsync(SearchProductsQuery request, CancellationToken cancellationToken);
}
