namespace MapsterIntro;

public class Student
{
    public string Name { get; set; }
    public string Family { get; set; }
    public Guid Id { get; private set; } = Guid.NewGuid();
}