namespace EFDualContextTest.Models;

public class Book
{
    public bool IsDeleted { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    private List<Author> _authors = new List<Author>();
    public IReadOnlyCollection<Author> Authors {
        get
        {
            return _authors.AsReadOnly();
        }
    }
}