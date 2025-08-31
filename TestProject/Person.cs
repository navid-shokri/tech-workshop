namespace TestProject;

public abstract class ValueObject<T> : IEquatable<T>
{
    public abstract bool checkPropertyEquality(T t);



    public bool Equals(T? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return checkPropertyEquality(other);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((T)obj);
    }

    public abstract override int GetHashCode();
}

public class Person : ValueObject<Person>//, IEquatable<Person>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }


    public override bool checkPropertyEquality(Person t)
    {
        return Name == t.Name && Family == t.Family;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Family);
    }

    /*public bool Equals(Person? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name && Family == other.Family;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Person)obj);
    }*/

}

[Flags]
public enum Relation
{
    None = 0,
    Father = 1,
    Mother = 2,
    Son = 4, 
    Dougther = 8
}