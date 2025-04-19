# ECommerce API

This is the API layer of the ECommerce application, built using ASP.NET Core. It provides RESTful endpoints for managing products, categories, orders, and customers.

## Authentication

The API uses JWT (JSON Web Token) authentication. To access protected endpoints, you need to include the JWT token in the Authorization header:

```
Authorization: Bearer <your_jwt_token>
```

### Authentication Endpoints

#### Register
```bash
curl -X POST http://localhost:5135/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "username": "testuser",
    "email": "test@example.com",
    "password": "Test123!"
  }'
```

#### Login
```bash
curl -X POST http://localhost:5135/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "test@example.com",
    "password": "Test123!"
  }'
```

#### Change Password
```bash
curl -X POST http://localhost:5135/api/auth/change-password \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer YOUR_JWT_TOKEN" \
  -d '{
    "currentPassword": "Test123!",
    "newPassword": "NewTest123!"
  }'
```

## Available Endpoints

### Categories

#### Get All Categories
```bash
curl -X GET http://localhost:5135/api/categories
```

#### Get Category by ID
```bash
curl -X GET http://localhost:5135/api/categories/{id}
```

#### Create Category
```bash
curl -X POST http://localhost:5135/api/categories \
  -H "Content-Type: application/json" \
  -d '{"name": "Electronics", "description": "Electronic devices and accessories"}'
```

#### Update Category
```bash
curl -X PUT http://localhost:5135/api/categories/{id} \
  -H "Content-Type: application/json" \
  -d '{"name": "Updated Electronics", "description": "Updated description"}'
```

#### Delete Category
```bash
curl -X DELETE http://localhost:5135/api/categories/{id}
```

#### Activate Category
```bash
curl -X POST http://localhost:5135/api/categories/{id}/activate
```

#### Deactivate Category
```bash
curl -X POST http://localhost:5135/api/categories/{id}/deactivate
```

### Products

#### Get All Products
```bash
curl -X GET http://localhost:5135/api/products
```

#### Get Product by ID
```bash
curl -X GET http://localhost:5135/api/products/{id}
```

#### Get Products by Category
```bash
curl -X GET http://localhost:5135/api/products/category/{categoryId}
```

#### Get Active Products
```bash
curl -X GET http://localhost:5135/api/products/active
```

#### Search Products
```bash
curl -X GET "http://localhost:5135/api/products/search?term=phone"
```

#### Create Product
```bash
curl -X POST http://localhost:5135/api/products \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Smartphone",
    "description": "Latest smartphone model",
    "price": 999.99,
    "stockQuantity": 100,
    "sku": "SM-001",
    "categoryId": "category-guid-here"
  }'
```

#### Update Product
```bash
curl -X PUT http://localhost:5135/api/products/{id} \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Updated Smartphone",
    "description": "Updated description",
    "price": 899.99,
    "stockQuantity": 50,
    "sku": "SM-001",
    "categoryId": "category-guid-here"
  }'
```

#### Delete Product
```bash
curl -X DELETE http://localhost:5135/api/products/{id}
```

#### Activate Product
```bash
curl -X POST http://localhost:5135/api/products/{id}/activate
```

#### Deactivate Product
```bash
curl -X POST http://localhost:5135/api/products/{id}/deactivate
```

## Development

### Prerequisites
- .NET 8 SDK
- SQL Server (or SQL Server Express)

### Running the Application
1. Update the connection string in `appsettings.json`
2. Run the following commands:
```bash
dotnet restore
dotnet run
```

The API will be available at:
- HTTP: http://localhost:5135
- HTTPS: https://localhost:5135

### Swagger Documentation
Swagger documentation is available at `/swagger` when running in development mode.

### Database Migrations
The application automatically applies database migrations on startup. If you need to create a new migration manually:

```bash
# Create a new migration
dotnet ef migrations add <MigrationName> --project src/ECommerceAPI.Infrastructure --startup-project src/ECommerceAPI.API

# Apply migrations
dotnet ef database update --project src/ECommerceAPI.Infrastructure --startup-project src/ECommerceAPI.API
``` 