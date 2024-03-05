using Microsoft.EntityFrameworkCore;
using ThunderWings.Domain.Products;

namespace ThunderWings.Application.Data;

public interface IApplicationDbContext
{
    public DbSet<Product> Products { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
