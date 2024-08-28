using System.Reflection.Metadata.Ecma335;
using StackExchange.Redis;

namespace MapsterIntro;

public class Person<T>
{
    public T Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public DateTime BirthDay { get; set; }

}