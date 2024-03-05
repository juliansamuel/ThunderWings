using MediatR;

namespace ThunderWings.Application.ProductRoles.Get;

public record GetProductRolesQuery() : IRequest<IReadOnlyList<ProductRoleResponse>>;
