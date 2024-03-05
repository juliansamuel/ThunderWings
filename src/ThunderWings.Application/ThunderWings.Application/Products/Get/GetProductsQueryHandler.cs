using MediatR;
using ThunderWings.Application.Products.Shared;

namespace ThunderWings.Application.Products.Get;

internal sealed class GetProductsQueryHandler
    : IRequestHandler<GetProductsQuery, IReadOnlyList<ProductResponse>>
{
    private readonly IProductReadService _productReadService;

    public GetProductsQueryHandler(IProductReadService productReadService)
    {
        _productReadService = productReadService;
    }

    public async Task<IReadOnlyList<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productReadService.GetAsync(cancellationToken);
    }
}
