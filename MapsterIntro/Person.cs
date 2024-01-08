using System.Reflection.Metadata.Ecma335;

namespace MapsterIntro;

public class Person<T>
{
    public T Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public DateTime BirthDay { get; set; }
}