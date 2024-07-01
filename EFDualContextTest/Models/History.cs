namespace EFDualContextTest.Models;

public class History
{
    private History()
    {
    }

    public History(Person person, string msg)
    {
        Id = Guid.NewGuid();
        Message = msg;
        PersonId = person.Id;
    }
    public string Message { get; private set; }
    public Guid Id { get; private set; }
    public Guid PersonId { get; private set; }
}