using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ThunderWings.Domain.Countries;
using ThunderWings.Domain.Manufacturers;
using ThunderWings.Domain.ProductRoles;
using ThunderWings.Domain.Products;

namespace ThunderWings.Application.Data;

public interface IApplicationDbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<ProductRole> ProductRoles { get; set; }

    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
