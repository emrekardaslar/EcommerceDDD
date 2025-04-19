# EcommerceDDD

A Domain-Driven Design (DDD) based E-commerce API built with .NET 8.0.

## Project Structure

The solution is organized into the following layers:

- **EcommerceDDD.API**: The presentation layer that handles HTTP requests and responses
- **EcommerceDDD.Application**: The application layer that implements business logic
- **EcommerceDDD.Domain**: The domain layer that contains business rules and entity definitions
- **EcommerceDDD.Infrastructure**: The infrastructure layer that handles data persistence and external services
- **EcommerceDDD.API.Tests**: Test project for the API layer

## Prerequisites

- .NET 8.0 SDK
- SQL Server (or SQL Server Express)
- Visual Studio 2022 or Visual Studio Code

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/EcommerceDDD.git
   cd EcommerceDDD
   ```

2. Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=EcommerceDDD;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. Apply database migrations:
   ```bash
   cd src/EcommerceDDD.API
   dotnet ef database update --project ../EcommerceDDD.Infrastructure
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

The API will be available at:
- https://localhost:5135
- http://localhost:5135

## Current Features

### Authentication
- JWT-based authentication
- User registration and login
- Role-based authorization

### Product Management
- Create, read, update, and delete products
- Product categorization
- Product activation/deactivation

### Category Management
- Create, read, update, and delete categories
- Category hierarchy support

### Order Management
- Create and manage orders
- Order status tracking
- Order history

### Customer Management
- Customer registration
- Customer profile management
- Address management (shipping and billing)

## API Documentation

Once the application is running, you can access the Swagger documentation at:
- https://localhost:5135/swagger
- http://localhost:5135/swagger

## Testing

To run the tests:
```bash
cd src/EcommerceDDD.API.Tests
dotnet test
```

## Development Guidelines

### Domain-Driven Design Principles
- The domain layer is the heart of the application
- Entities and value objects represent the business domain
- Aggregates maintain consistency boundaries
- Repositories provide persistence abstraction

### Code Organization
- Each layer has its own responsibilities
- Dependencies flow inward (API → Application → Domain)
- Infrastructure implements interfaces defined in the domain

### Best Practices
- Use dependency injection
- Follow SOLID principles
- Implement proper error handling
- Write unit tests for business logic

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details. 