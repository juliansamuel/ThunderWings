using MediatR;
using ThunderWings.Application.Products.Shared;

namespace ThunderWings.Application.Products.Get;

public record GetProductsQuery() : IRequest<IReadOnlyList<ProductResponse>>;
