using EcommerceDDD.Domain.Common;
using EcommerceDDD.Domain.Entities.Customers;

namespace EcommerceDDD.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByEmailAsync(string email);
    Task<IEnumerable<Customer>> GetActiveCustomersAsync();
    Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm);
} 