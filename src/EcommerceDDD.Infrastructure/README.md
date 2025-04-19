# ECommerce Infrastructure Layer

This is the infrastructure layer of the ECommerce system, responsible for data persistence, external services, and technical implementations.

## Structure

The infrastructure layer is organized into the following main components:

### Persistence
- `ApplicationDbContext`: Entity Framework Core database context
- `BaseRepository<T>`: Generic repository implementation
- `ProductRepository`: Product-specific repository implementation
- `CategoryRepository`: Category-specific repository implementation
- `CustomerRepository`: Customer-specific repository implementation
- `OrderRepository`: Order-specific repository implementation
- `UserRepository`: User-specific repository implementation

### Migrations
- Database migration files for Entity Framework Core
- Database schema definitions and updates

## Responsibilities

1. **Data Persistence**
   - Implements repository interfaces defined in the domain layer
   - Handles database operations and transactions
   - Manages database connections and context

2. **External Services**
   - Implements integrations with external systems
   - Handles communication with third-party services
   - Manages external API calls and responses

3. **Technical Concerns**
   - Implements cross-cutting concerns
   - Handles logging, caching, and other infrastructure services
   - Manages configuration and environment-specific settings

## Dependencies

- Domain Layer: Implements repository interfaces and uses domain entities
- Application Layer: Provides services for the application layer

## Usage

The infrastructure layer is used by the application layer to handle data persistence and external services. It should not be directly accessed by the API layer.

Example repository implementation:

```csharp
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(Guid categoryId)
    {
        return await _dbSet
            .Where(p => p.CategoryId == categoryId && p.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetActiveProductsAsync()
    {
        return await _dbSet
            .Where(p => p.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
    {
        return await _dbSet
            .Where(p => p.IsActive && 
                   (p.Name.Contains(searchTerm) || 
                    p.Description.Contains(searchTerm) ||
                    p.Sku.Contains(searchTerm)))
            .ToListAsync();
    }
}
```

## Database Configuration

The infrastructure layer uses Entity Framework Core with SQL Server. The database connection string should be configured in the API layer's `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ECommerce;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

## Migrations

To create and apply database migrations:

```bash
# Create a new migration
dotnet ef migrations add <MigrationName> --project src/EcommerceDDD.Infrastructure --startup-project src/EcommerceDDD.API

# Apply migrations
dotnet ef database update --project src/EcommerceDDD.Infrastructure --startup-project src/EcommerceDDD.API
``` 