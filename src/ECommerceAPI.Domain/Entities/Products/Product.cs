using ECommerceAPI.Domain.Common;

namespace ECommerceAPI.Domain.Entities.Products;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    public string Sku { get; private set; }
    public bool IsActive { get; private set; }

    // Navigation properties
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    private Product() { } // For EF Core

    public Product(string name, string description, decimal price, int stockQuantity, string sku, Guid categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        Sku = sku;
        CategoryId = categoryId;
        IsActive = true;
    }

    public void UpdateDetails(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public void UpdateStock(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("Stock quantity cannot be negative");
        
        StockQuantity = quantity;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
} 