# ECommerce API

This is the API layer of the ECommerce application, built using ASP.NET Core. It provides RESTful endpoints for managing products, categories, orders, and customers.

## Authentication

The API uses JWT (JSON Web Token) authentication. To access protected endpoints, you need to include the JWT token in the Authorization header:

```
Authorization: Bearer <your_jwt_token>
```

## Available Endpoints

### Categories

#### Get All Categories
```bash
curl -X GET https://localhost:5001/api/categories
```

#### Get Category by ID
```bash
curl -X GET https://localhost:5001/api/categories/{id}
```

#### Create Category
```bash
curl -X POST https://localhost:5001/api/categories \
  -H "Content-Type: application/json" \
  -d '{"name": "Electronics", "description": "Electronic devices and accessories"}'
```

#### Update Category
```bash
curl -X PUT https://localhost:5001/api/categories/{id} \
  -H "Content-Type: application/json" \
  -d '{"name": "Updated Electronics", "description": "Updated description"}'
```

#### Delete Category
```bash
curl -X DELETE https://localhost:5001/api/categories/{id}
```

#### Activate Category
```bash
curl -X POST https://localhost:5001/api/categories/{id}/activate
```

#### Deactivate Category
```bash
curl -X POST https://localhost:5001/api/categories/{id}/deactivate
```

### Products

#### Get All Products
```bash
curl -X GET https://localhost:5001/api/products
```

#### Get Product by ID
```bash
curl -X GET https://localhost:5001/api/products/{id}
```

#### Get Products by Category
```bash
curl -X GET https://localhost:5001/api/products/category/{categoryId}
```

#### Get Active Products
```bash
curl -X GET https://localhost:5001/api/products/active
```

#### Search Products
```bash
curl -X GET "https://localhost:5001/api/products/search?term=phone"
```

#### Create Product
```bash
curl -X POST https://localhost:5001/api/products \
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
curl -X PUT https://localhost:5001/api/products/{id} \
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
curl -X DELETE https://localhost:5001/api/products/{id}
```

#### Activate Product
```bash
curl -X POST https://localhost:5001/api/products/{id}/activate
```

#### Deactivate Product
```bash
curl -X POST https://localhost:5001/api/products/{id}/deactivate
```

### Authentication

#### Register
```bash
curl -X POST https://localhost:5001/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "your_password",
    "firstName": "John",
    "lastName": "Doe"
  }'
```

#### Login
```bash
curl -X POST https://localhost:5001/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "user@example.com",
    "password": "your_password"
  }'
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

The API will be available at `https://localhost:5001` and `http://localhost:5000`.

### Swagger Documentation
Swagger documentation is available at `/swagger` when running in development mode. 