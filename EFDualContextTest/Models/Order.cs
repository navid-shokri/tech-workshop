namespace EFDualContextTest.Models;

public class Order : BaseEntity
{
    public Order(long totalPrice)
    {
        TotalPrice = totalPrice;
    }
    //v1
    public Person Owner { get; private set; }

    public void SetOwner(Person person)
    {
        Owner = person;
    }

    //v2
    //--
    public long TotalPrice { get; private set; }
    protected override void Validate()
    {
        
    }
}