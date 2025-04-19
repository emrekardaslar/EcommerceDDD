using ECommerceAPI.Domain.Common;
using ECommerceAPI.Domain.Entities.Customers;

namespace ECommerceAPI.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetByEmailAsync(string email);
    Task<IEnumerable<Customer>> GetActiveCustomersAsync();
    Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm);
} 