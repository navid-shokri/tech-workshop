namespace EFDualContextTest.Models;

public class Address
{
    protected Address()
    {
        
    }

    public Address(string city, string street)
    {
        City = city;
        Street = street;
    }

    public string City { get; private set; }
    public string Street { get; private set; }
}