using System.Security.Cryptography;

namespace TestRuleEngine;

public class Customer
{
    public string Name { get; set; }
    public DateTime BirthDay { get; set; }
    public int Balance { get; set; }
    public Address Address { get; set; }
    public string Message { get; set; }

    public int Age{
        get
        {
            var age = DateTime.Today.Year - BirthDay.Year;
            if (BirthDay.Date > DateTime.Today.AddYears(-age)) age--;
            return age;
        }
    }
}

public class Address
{
    public string City { get; set; }
    public string SreetAddress { get; set; }
}