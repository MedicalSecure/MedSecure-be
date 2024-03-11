namespace Waste.Domain.ValueObjects;
public record Address
{
    public string Street { get; } = default!;
    public string City { get; } = default!;
    public string State { get; } = default!;
    public string ZipCode { get; } = default!;
    public string Country { get; } = default!;
    public string Phone { get; } = default!;
    public string Email { get; } = default!;



    public Address()
    {

    }

    public Address(string street, string city, string state, string zipCode, string country, string phone, string email)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
        Phone = phone;
        Email = email;
    }

    public static Address Of(string street, string city, string state, string zipCode, string country, string phone, string email)
    {
        // Validation logic
        ArgumentException.ThrowIfNullOrWhiteSpace(phone);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        return new Address(street,city, state, zipCode, country, phone, email);
    }
}