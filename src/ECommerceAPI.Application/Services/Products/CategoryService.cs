using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Domain.Repositories;

namespace ECommerceAPI.Application.Services.Products;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _categoryRepository;

    public CategoryService(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found");

        return category;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> CreateCategoryAsync(string name, string description)
    {
        var category = new Category(name, description);
        await _categoryRepository.AddAsync(category);
        return category;
    }

    public async Task UpdateCategoryAsync(Guid id, string name, string description)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found");

        category.UpdateDetails(name, description);
        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found");

        await _categoryRepository.DeleteAsync(category);
    }

    public async Task ActivateCategoryAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found");

        category.Activate();
        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeactivateCategoryAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {id} not found");

        category.Deactivate();
        await _categoryRepository.UpdateAsync(category);
    }
} 