using Microsoft.EntityFrameworkCore;
using ThunderWings.Domain.Products;

namespace ThunderWings.Infrastructure.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Product?> GetByIdAsync(ProductId id)
    {
        return _context.Products
            .SingleOrDefaultAsync(p => p.Id == id);
    }
}
