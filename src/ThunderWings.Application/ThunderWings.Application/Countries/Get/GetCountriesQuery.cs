using MediatR;

namespace ThunderWings.Application.Countries.Get;

public record GetCountriesQuery() : IRequest<IReadOnlyList<CountryResponse>>;
