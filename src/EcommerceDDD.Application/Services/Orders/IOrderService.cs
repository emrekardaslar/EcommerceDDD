using EcommerceDDD.Domain.Entities.Orders;
using EcommerceDDD.Domain.ValueObjects;

namespace EcommerceDDD.Application.Services.Orders;

public interface IOrderService
{
    Task<Order?> GetOrderByIdAsync(Guid id);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
    Task<Order> CreateOrderAsync(Guid customerId, Address shippingAddress, Address billingAddress);
    Task AddItemToOrderAsync(Guid orderId, Guid productId, int quantity);
    Task RemoveItemFromOrderAsync(Guid orderId, Guid orderItemId);
    Task UpdateOrderStatusAsync(Guid orderId, OrderStatus newStatus);
    Task DeleteOrderAsync(Guid orderId);
} 