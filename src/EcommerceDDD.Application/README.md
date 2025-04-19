# ECommerce Application Layer

This is the application layer of the ECommerce system, implementing the business logic and use cases of the application.

## Structure

The application layer is organized into the following main components:

### Services
- `IProductService` and `ProductService`: Handles product-related business logic
- `ICategoryService` and `CategoryService`: Manages category operations
- `IAuthService` and `AuthService`: Handles authentication and authorization

### DTOs (Data Transfer Objects)
- `ProductDto`: Represents product data for API responses
- `CreateProductDto`: Used for creating new products
- `UpdateProductDto`: Used for updating existing products

## Responsibilities

1. **Business Logic Implementation**
   - Implements use cases and business rules
   - Coordinates between domain entities and infrastructure
   - Handles validation and business rules

2. **Data Transformation**
   - Maps between domain entities and DTOs
   - Handles data validation and transformation

3. **Service Orchestration**
   - Coordinates between different services
   - Manages transactions and business processes

## Dependencies

- Domain Layer: For entity definitions and business rules
- Infrastructure Layer: For data persistence and external services

## Usage

The application layer is used by the API layer to handle business logic and data transformation. It should not have any direct dependencies on the infrastructure layer, following the Dependency Inversion Principle.

Example usage in a controller:

```csharp
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productService.GetByIdAsync(id);
        return Ok(product);
    }
}
``` 