namespace ECommerceAPI.Domain.ValueObjects;

public record Address
{
    public string Street { get; private init; }
    public string City { get; private init; }
    public string State { get; private init; }
    public string Country { get; private init; }
    public string ZipCode { get; private init; }

    private Address() { } // For EF Core

    public Address(string street, string city, string state, string country, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be empty");
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty");
        if (string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("State cannot be empty");
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be empty");
        if (string.IsNullOrWhiteSpace(zipCode))
            throw new ArgumentException("ZipCode cannot be empty");

        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}, {ZipCode}";
    }
} 