namespace ECommerceAPI.Application.DTOs.Products;

public record CreateProductDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
    public string Sku { get; init; }
    public Guid CategoryId { get; init; }
} 