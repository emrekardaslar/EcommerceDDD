namespace EcommerceDDD.Application.DTOs.Products;

public record ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
    public string Sku { get; init; }
    public bool IsActive { get; init; }
    public Guid CategoryId { get; init; }
    public string CategoryName { get; init; }
} 