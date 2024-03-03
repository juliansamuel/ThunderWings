namespace ThunderWings.Application.Products.Shared;

public record ProductResponse(
    Guid Id,
    string Name,
    string Country,
    string Manufacturer,
    string ProductRole,
    decimal TopSpeed,
    decimal Price);
