using ECommerceAPI.Domain.Common;
using ECommerceAPI.Domain.Entities.Products;

namespace ECommerceAPI.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId);
    Task<IEnumerable<Product>> GetActiveProductsAsync();
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
} 