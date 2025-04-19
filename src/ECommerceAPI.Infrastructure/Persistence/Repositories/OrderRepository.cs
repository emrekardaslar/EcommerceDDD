using ECommerceAPI.Domain.Entities.Orders;
using ECommerceAPI.Domain.Repositories;
using ECommerceAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Infrastructure.Persistence.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _dbSet
            .Where(o => o.CustomerId == customerId)
            .Include(o => o.Items)
            .ThenInclude(oi => oi.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetByStatusAsync(OrderStatus status)
    {
        return await _dbSet
            .Where(o => o.Status == status)
            .Include(o => o.Items)
            .ThenInclude(oi => oi.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _dbSet
            .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate)
            .Include(o => o.Items)
            .ThenInclude(oi => oi.Product)
            .ToListAsync();
    }
} 