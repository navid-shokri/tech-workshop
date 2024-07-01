namespace EFDualContextTest.Models;

public class Order : BaseEntity
{
    //v1
    public Person Owner { get; private set; }

    public void SetOwner(Person person)
    {
        Owner = person;
    }

    //v2
    //--
    public long TotalPrice { get; set; }
    protected override void Validate()
    {
        
    }
}