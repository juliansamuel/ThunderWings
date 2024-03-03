using Microsoft.EntityFrameworkCore;
using ThunderWings.Domain.Countries;
using ThunderWings.Domain.Manufacturers;
using ThunderWings.Domain.ProductRoles;
using ThunderWings.Domain.Products;

namespace ThunderWings.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<ProductRole> ProductRoles { get; set; }
}
