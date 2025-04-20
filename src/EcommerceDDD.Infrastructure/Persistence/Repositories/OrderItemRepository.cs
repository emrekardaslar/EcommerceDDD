using EcommerceDDD.Domain.Entities.Orders;
using EcommerceDDD.Domain.Repositories;

namespace EcommerceDDD.Infrastructure.Persistence.Repositories;

public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}

