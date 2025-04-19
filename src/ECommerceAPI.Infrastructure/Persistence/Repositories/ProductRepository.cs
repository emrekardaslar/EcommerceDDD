using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Domain.Repositories;
using ECommerceAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Infrastructure.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId)
    {
        return await _dbSet
            .Where(p => p.CategoryId == categoryId && p.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetActiveProductsAsync()
    {
        return await _dbSet
            .Where(p => p.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
    {
        return await _dbSet
            .Where(p => p.IsActive && 
                   (p.Name.Contains(searchTerm) || 
                    p.Description.Contains(searchTerm) ||
                    p.Sku.Contains(searchTerm)))
            .ToListAsync();
    }
} 