namespace EFDualContextTest.Models;

public class Author
{
    public bool IsDeleted { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    private List<Book> _books = new List<Book>();
    public IReadOnlyCollection<Book> Books
    {
        get { return _books.AsReadOnly(); }
    }

    public void SetBooks(List<Book> books)
    {
        _books = books;
    }
}