using MediatR;
using ThunderWings.Application.Products.Shared;

namespace ThunderWings.Application.Products.Search;

internal sealed class SearchProductsQueryHandler
    : IRequestHandler<SearchProductsQuery, PagedList<ProductResponse>>
{
    private readonly IProductReadService _productReadService;

    public SearchProductsQueryHandler(IProductReadService productReadService)
    {
        _productReadService = productReadService;
    }

    public async Task<PagedList<ProductResponse>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productReadService.SearchAsync(request, cancellationToken);
    }
}
