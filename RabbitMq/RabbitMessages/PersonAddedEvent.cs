using MessagePack;

namespace RabbitMessages;

[MessagePackObject]
public class PersonAddedEvent
{
    public PersonAddedEvent(string name, string family)
    {
        Name = name;
        Family = family;
    }
    [Key(0)]  
    public string Name { get; set; }
    [Key(1)]
    public string Family { get; set; }
}