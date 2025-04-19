using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Infrastructure.Persistence;

namespace ECommerceAPI.Infrastructure.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
} 