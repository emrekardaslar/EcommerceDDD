using ECommerceAPI.Domain.Common;
using ECommerceAPI.Domain.Entities.Customers;
using ECommerceAPI.Domain.ValueObjects;

namespace ECommerceAPI.Domain.Entities.Orders;

public class Order : BaseEntity
{
    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public OrderStatus Status { get; private set; }
    public Money TotalAmount { get; private set; }
    public Address ShippingAddress { get; private set; }
    public Address BillingAddress { get; private set; }

    // Navigation properties
    public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();

    private Order() { } // For EF Core

    public Order(Guid customerId, Address shippingAddress, Address billingAddress)
    {
        CustomerId = customerId;
        Status = OrderStatus.Pending;
        TotalAmount = new Money(0);
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
        CalculateTotal();
        Update();
    }

    public void RemoveItem(OrderItem item)
    {
        Items.Remove(item);
        CalculateTotal();
        Update();
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        Status = newStatus;
        Update();
    }

    private void CalculateTotal()
    {
        TotalAmount = new Money(Items.Sum(item => item.Subtotal.Amount));
    }
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
} 