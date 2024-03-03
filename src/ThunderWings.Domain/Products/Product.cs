using ThunderWings.Domain.Countries;
using ThunderWings.Domain.Manufacturers;
using ThunderWings.Domain.ProductRoles;

namespace ThunderWings.Domain.Products;

public class Product
{
    public Product(ProductId id, CountryId countryId, ManufacturerId manufacturerId, ProductRoleId productRoleId, string name, decimal topSpeed, decimal price)
    {
        Id = id;
        CountryId = countryId;
        ManufacturerId = manufacturerId;
        ProductRoleId = productRoleId;
        Name = name;
        TopSpeed = topSpeed;
        Price = price;
    }

    private Product()
    {
    }

    public ProductId Id { get; private set; }

    public CountryId CountryId { get; private set; }

    public Country Country { get; private set; }

    public ManufacturerId ManufacturerId { get; private set; }

    public Manufacturer Manufacturer { get; private set; }

    public ProductRoleId ProductRoleId { get; private set; }

    public ProductRole ProductRole { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public decimal TopSpeed { get; private set; }

    public void Update(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
