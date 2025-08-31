namespace EFDualContextTest.Models;

public class Seller : BaseEntity
{
    private List<Product> _products = new List<Product>();
    public string Address { get; set; }
    public IReadOnlyCollection<Product>? Product => _products.AsReadOnly();

    protected override void Validate()
    {
    }
}