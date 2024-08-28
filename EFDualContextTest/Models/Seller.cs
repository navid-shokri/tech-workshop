namespace EFDualContextTest.Models;

public class Seller : BaseEntity
{
    public string Address { get; set; }
    public Product Product { get; set; }
    public Guid ProductId { get; set; }

    protected override void Validate()
    {
    }
}