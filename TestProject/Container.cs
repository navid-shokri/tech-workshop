namespace TestProject;

public class Container
{
    
    public List<Content> Content { get; set; }
    public string Name { get; set; }
}

public class Content : IComparable<Content>
{
    public DateTime Departure { get; set; }

    public int CompareTo(Content? other)
    {
        int? i = 10;
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Departure.CompareTo(other.Departure);
    }
}