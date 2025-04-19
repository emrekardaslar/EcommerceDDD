using ECommerceAPI.Application.DTOs.Products;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Domain.Repositories;

namespace ECommerceAPI.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IRepository<Category> _categoryRepository;

    public ProductService(IProductRepository productRepository, IRepository<Category> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ProductDto> GetByIdAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {id} not found");

        var category = await _categoryRepository.GetByIdAsync(product.CategoryId);
        return MapToDto(product, category);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return await MapToDtos(products);
    }

    public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(Guid categoryId)
    {
        var products = await _productRepository.GetByCategoryAsync(categoryId);
        return await MapToDtos(products);
    }

    public async Task<IEnumerable<ProductDto>> GetActiveProductsAsync()
    {
        var products = await _productRepository.GetActiveProductsAsync();
        return await MapToDtos(products);
    }

    public async Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchTerm)
    {
        var products = await _productRepository.SearchProductsAsync(searchTerm);
        return await MapToDtos(products);
    }

    public async Task<ProductDto> CreateAsync(CreateProductDto dto)
    {
        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {dto.CategoryId} not found");

        var product = new Product(
            dto.Name,
            dto.Description,
            dto.Price,
            dto.StockQuantity,
            dto.Sku,
            dto.CategoryId
        );

        await _productRepository.AddAsync(product);
        return MapToDto(product, category);
    }

    public async Task UpdateAsync(Guid id, CreateProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {id} not found");

        var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (category == null)
            throw new KeyNotFoundException($"Category with ID {dto.CategoryId} not found");

        product.UpdateDetails(dto.Name, dto.Description, dto.Price);
        product.UpdateStock(dto.StockQuantity);
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {id} not found");

        await _productRepository.DeleteAsync(product);
    }

    public async Task ActivateAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {id} not found");

        product.Activate();
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeactivateAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
            throw new KeyNotFoundException($"Product with ID {id} not found");

        product.Deactivate();
        await _productRepository.UpdateAsync(product);
    }

    private async Task<IEnumerable<ProductDto>> MapToDtos(IEnumerable<Product> products)
    {
        var dtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var category = await _categoryRepository.GetByIdAsync(product.CategoryId);
            dtos.Add(MapToDto(product, category));
        }
        return dtos;
    }

    private static ProductDto MapToDto(Product product, Category category)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            Sku = product.Sku,
            IsActive = product.IsActive,
            CategoryId = product.CategoryId,
            CategoryName = category?.Name ?? string.Empty
        };
    }
} 