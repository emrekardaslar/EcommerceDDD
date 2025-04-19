# ECommerce Domain Layer

This is the domain layer of the ECommerce system, containing the core business entities, rules, and interfaces.

## Structure

The domain layer is organized into the following main components:

### Entities
- `Product`: Represents a product in the system
- `Category`: Represents a product category
- `Customer`: Represents a customer
- `Order`: Represents an order
- `OrderItem`: Represents an item in an order
- `User`: Represents a system user

### Value Objects
- `Address`: Represents a physical address
- `Money`: Represents monetary values with currency

### Repositories
- `IRepository<T>`: Generic repository interface
- `IProductRepository`: Product-specific repository interface
- `ICategoryRepository`: Category-specific repository interface
- `ICustomerRepository`: Customer-specific repository interface
- `IOrderRepository`: Order-specific repository interface

### Common
- `BaseEntity`: Base class for all entities
- Common interfaces and base classes

## Responsibilities

1. **Business Rules**
   - Defines the core business rules and constraints
   - Implements domain logic and validations
   - Maintains business invariants

2. **Entity Definitions**
   - Defines the structure and behavior of domain entities
   - Implements entity relationships and constraints
   - Maintains entity state and lifecycle

3. **Repository Contracts**
   - Defines interfaces for data access
   - Specifies data access requirements
   - Maintains separation of concerns

## Dependencies

The domain layer should have no dependencies on other layers. It is the core of the application and should be independent of infrastructure concerns.

## Usage

The domain layer is used by both the application and infrastructure layers:

- Application layer uses domain entities and interfaces to implement business logic
- Infrastructure layer implements the repository interfaces defined in the domain layer

Example entity:

```csharp
public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    public string Sku { get; private set; }
    public bool IsActive { get; private set; }

    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

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

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}
``` 