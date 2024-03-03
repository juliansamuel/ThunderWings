using System.Text.Json;
using ThunderWings.Domain.Countries;
using ThunderWings.Domain.Manufacturers;
using ThunderWings.Domain.ProductRoles;
using ThunderWings.Domain.Products;
using ThunderWings.Infrastructure;

namespace ThunderWings.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedProductData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Seed data from json file if Products table is empty
        if (!context.Products.Any())
        {
            var aircraftDataPath = Path.Combine(Directory.GetCurrentDirectory(), "aircraft.json");
            var jsonData = File.ReadAllText(aircraftDataPath).ToString();
            var aircrafts = JsonSerializer.Deserialize<List<Aircraft>>(jsonData);
            var countries = new List<Country>();
            var manufacturers = new List<Manufacturer>();
            var productRoles = new List<ProductRole>();
            var products = new List<Product>();

            foreach (var aircraft in aircrafts!)
            {
                var country = countries.Find(x => x.Name == aircraft.Country);
                if (country == null)
                {
                    country = new Country(new CountryId(Guid.NewGuid()), aircraft.Country);
                    countries.Add(country);
                }

                var manufacturer = manufacturers.Find(x => x.Name == aircraft.Manufacturer);
                if (manufacturer == null)
                {
                    manufacturer = new Manufacturer(new ManufacturerId(Guid.NewGuid()), aircraft.Manufacturer);
                    manufacturers.Add(manufacturer);
                }

                var productRole = productRoles.Find(x => x.Name == aircraft.ProductRole);
                if (productRole == null)
                {
                    productRole = new ProductRole(new ProductRoleId(Guid.NewGuid()), aircraft.ProductRole);
                    productRoles.Add(productRole);
                }

                var product = new Product(
                    new ProductId(Guid.NewGuid()),
                    country.Id,
                    manufacturer.Id,
                    productRole.Id,
                    aircraft.Name,
                    aircraft.TopSpeed,
                    aircraft.Price
                );
                products.Add(product);
            }

            context.Countries.AddRange(countries);
            context.Manufacturers.AddRange(manufacturers);
            context.ProductRoles.AddRange(productRoles);
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
