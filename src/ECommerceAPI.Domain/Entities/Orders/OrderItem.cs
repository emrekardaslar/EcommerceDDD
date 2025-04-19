using ECommerceAPI.Domain.Common;
using ECommerceAPI.Domain.Entities.Products;
using ECommerceAPI.Domain.ValueObjects;

namespace ECommerceAPI.Domain.Entities.Orders;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; private set; }
    public Order Order { get; private set; }
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public Money UnitPrice { get; private set; }
    public Money Subtotal { get; private set; }

    private OrderItem() { } // For EF Core

    public OrderItem(Guid orderId, Guid productId, int quantity, Money unitPrice)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        CalculateSubtotal();
    }

    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");

        Quantity = newQuantity;
        CalculateSubtotal();
        Update();
    }

    private void CalculateSubtotal()
    {
        Subtotal = UnitPrice * Quantity;
    }
} 