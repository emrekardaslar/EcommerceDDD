using EcommerceDDD.Domain.Common;
using EcommerceDDD.Domain.Entities.Orders;
using EcommerceDDD.Domain.ValueObjects;

namespace EcommerceDDD.Domain.Entities.Customers;

public class Customer : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Address ShippingAddress { get; set; }
    public Address BillingAddress { get; set; }
    public bool IsActive { get; set; }

    // Navigation properties
    public ICollection<Order> Orders { get; set; } = new List<Order>();

    public Customer() { } // For JSON deserialization

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