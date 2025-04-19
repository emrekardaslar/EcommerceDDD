using EcommerceDDD.Domain.Entities.Products;

namespace EcommerceDDD.Application.Services.Products;

public interface ICategoryService
{
    Task<Category> GetByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> CreateCategoryAsync(string name, string description);
    Task UpdateCategoryAsync(Guid id, string name, string description);
    Task DeleteCategoryAsync(Guid id);
    Task ActivateCategoryAsync(Guid id);
    Task DeactivateCategoryAsync(Guid id);
} 