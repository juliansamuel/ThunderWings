using MediatR;
using Microsoft.EntityFrameworkCore;
using ThunderWings.Application.Data;
using ThunderWings.Domain.Countries;
using ThunderWings.Domain.Manufacturers;
using ThunderWings.Domain.ProductRoles;
using ThunderWings.Domain.Products;

namespace ThunderWings.Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    public ApplicationDbContext(DbContextOptions options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
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
