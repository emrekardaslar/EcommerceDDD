using ECommerceAPI.Domain.Common;
using ECommerceAPI.Domain.Entities.Orders;
using ECommerceAPI.Domain.ValueObjects;

namespace ECommerceAPI.Domain.Entities.Customers;

public class Customer : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public Address ShippingAddress { get; private set; }
    public Address BillingAddress { get; private set; }
    public bool IsActive { get; private set; }

    // Navigation properties
    public ICollection<Order> Orders { get; private set; } = new List<Order>();

    private Customer() { } // For EF Core

    public Customer(string firstName, string lastName, string email, string phoneNumber, 
        Address shippingAddress, Address billingAddress)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        IsActive = true;
    }

    public void UpdateDetails(string firstName, string lastName, string email, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Update();
    }

    public void UpdateAddresses(Address shippingAddress, Address billingAddress)
    {
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Update();
    }

    public void Deactivate()
    {
        IsActive = false;
        Update();
    }

    public void Activate()
    {
        IsActive = true;
        Update();
    }
} 