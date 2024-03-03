namespace ThunderWings.Domain.Products;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(ProductId id);
}