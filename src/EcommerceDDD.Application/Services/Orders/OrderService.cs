using EcommerceDDD.Domain.Entities.Orders;
using EcommerceDDD.Domain.Repositories;
using EcommerceDDD.Domain.ValueObjects;

namespace EcommerceDDD.Application.Services.Orders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICustomerRepository _customerRepository;

    public OrderService(
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        ICustomerRepository customerRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _customerRepository = customerRepository;
    }

    public async Task<Order?> GetOrderByIdAsync(Guid id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
    {
        return await _orderRepository.GetByCustomerIdAsync(customerId);
    }

    public async Task<Order> CreateOrderAsync(Guid customerId, Address shippingAddress, Address billingAddress)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        if (customer == null)
            throw new ArgumentException("Customer not found");

        var order = new Order(customerId, shippingAddress, billingAddress);
        await _orderRepository.AddAsync(order);
        return order;
    }

    public async Task AddItemToOrderAsync(Guid orderId, Guid productId, int quantity)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
            throw new ArgumentException("Order not found");

        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null)
            throw new ArgumentException("Product not found");

        if (product.StockQuantity < quantity)
            throw new ArgumentException("Insufficient stock");

        var unitPrice = new Money(product.Price);
        var orderItem = new OrderItem(orderId, productId, quantity, unitPrice);
        order.AddItem(orderItem);

        product.UpdateStock(product.StockQuantity - quantity);
        await _productRepository.UpdateAsync(product);
        await _orderRepository.UpdateAsync(order);
    }

    public async Task RemoveItemFromOrderAsync(Guid orderId, Guid orderItemId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
            throw new ArgumentException("Order not found");

        var orderItem = order.Items.FirstOrDefault(i => i.Id == orderItemId);
        if (orderItem == null)
            throw new ArgumentException("Order item not found");

        var product = await _productRepository.GetByIdAsync(orderItem.ProductId);
        if (product == null)
            throw new ArgumentException("Product not found");

        order.RemoveItem(orderItem);
        product.UpdateStock(product.StockQuantity + orderItem.Quantity);

        await _productRepository.UpdateAsync(product);
        await _orderRepository.UpdateAsync(order);
    }

    public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus newStatus)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
            throw new ArgumentException("Order not found");

        order.UpdateStatus(newStatus);
        await _orderRepository.UpdateAsync(order);
    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
            throw new ArgumentException("Order not found");

        // Return items to stock
        foreach (var item in order.Items)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            if (product != null)
            {
                product.UpdateStock(product.StockQuantity + item.Quantity);
                await _productRepository.UpdateAsync(product);
            }
        }

        await _orderRepository.DeleteAsync(order);
    }
} 