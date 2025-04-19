namespace EcommerceDDD.Domain.ValueObjects;

public record Address
{
    public string Street { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Country { get; init; }
    public string ZipCode { get; init; }

    public Address() { } // For JSON deserialization

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