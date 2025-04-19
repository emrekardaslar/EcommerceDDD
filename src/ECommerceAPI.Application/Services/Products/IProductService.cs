using ECommerceAPI.Application.DTOs.Products;

namespace ECommerceAPI.Application.Services.Products;

public interface IProductService
{
    Task<ProductDto> GetByIdAsync(Guid id);
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<IEnumerable<ProductDto>> GetByCategoryAsync(Guid categoryId);
    Task<IEnumerable<ProductDto>> GetActiveProductsAsync();
    Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm);
    Task<ProductDto> CreateAsync(CreateProductDto dto);
    Task UpdateAsync(Guid id, CreateProductDto dto);
    Task DeleteAsync(Guid id);
    Task ActivateAsync(Guid id);
    Task DeactivateAsync(Guid id);
} 