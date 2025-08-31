namespace EFDualContextTest.Models;

public class Product:BaseEntity
{
    public string Title { get; set; }
    public int Price { get; set; }
   


    protected override void Validate()
    {
    }
}