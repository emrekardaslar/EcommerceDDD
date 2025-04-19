using EcommerceDDD.Domain.Common;
using EcommerceDDD.Domain.Entities.Products;

namespace EcommerceDDD.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId);
    Task<IEnumerable<Product>> GetActiveProductsAsync();
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
} 