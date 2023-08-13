using MessagePack;

namespace RabbitMessages;

[MessagePackObject]
public class PersonDeletedEvent
{
    [Key(0)]
    public string Name { get; set; }
    [Key(1)]
    public string Family { get; set; }
    public PersonDeletedEvent(string name, string family)
    {
        Name = name;
        Family = family;
    }
}