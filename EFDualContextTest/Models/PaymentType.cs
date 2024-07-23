namespace EFDualContextTest.Models;

public abstract class PaymentType
{
    public string Type { get; set; }
    public string Reference { get; set; }
    public string Issuer { get; set; }
}

public class CreditCard : PaymentType
{
    public CreditCard()
    {
        Type = "CC";
    }
}

public class GiftCard : PaymentType
{
    public GiftCard()
    {
        Type = "GC";
    }
}
