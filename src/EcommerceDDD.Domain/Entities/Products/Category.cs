using EcommerceDDD.Domain.Common;

namespace EcommerceDDD.Domain.Entities.Products;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; }

    // Navigation properties
    public ICollection<Product> Products { get; private set; } = new List<Product>();

    private Category() { } // For EF Core

    public Category(string name, string description)
    {
        Name = name;
        Description = description;
        IsActive = true;
    }

    public void UpdateDetails(string name, string description)
    {
        Name = name;
        Description = description;
        Update();
    }

    public void Deactivate()
    {
        IsActive = false;
        Update();
    }

    public void Activate()
    {
        IsActive = true;
        Update();
    }
} 