using ECommerceAPI.Domain.Entities.Customers;
using ECommerceAPI.Domain.Repositories;
using ECommerceAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Infrastructure.Persistence.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        return await _dbSet
            .FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task<IEnumerable<Customer>> GetActiveCustomersAsync()
    {
        return await _dbSet
            .Where(c => c.IsActive)
            .ToListAsync();
    }

    public async Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm)
    {
        return await _dbSet
            .Where(c => c.IsActive && 
                   (c.FirstName.Contains(searchTerm) || 
                    c.LastName.Contains(searchTerm) ||
                    c.Email.Contains(searchTerm) ||
                    c.PhoneNumber.Contains(searchTerm)))
            .ToListAsync();
    }
} 