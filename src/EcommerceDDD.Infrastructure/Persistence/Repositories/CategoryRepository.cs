using EcommerceDDD.Domain.Entities.Products;
using EcommerceDDD.Infrastructure.Persistence;

namespace EcommerceDDD.Infrastructure.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
} 