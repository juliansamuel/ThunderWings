using MediatR;

namespace ThunderWings.Application.Manufacturers.Get;

public record GetManufacturersQuery() : IRequest<IReadOnlyList<ManufacturerResponse>>;
