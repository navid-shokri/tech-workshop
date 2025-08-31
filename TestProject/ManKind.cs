namespace TestProject;

public class ManKind
{
    private ManKind()
    {
    }

    public ManKind(string name)
    {
        FullName = name;
        Age = 18;
    }

    public string FullName { get; private set; }
    public int Age { get; private set; }
    public NewAddress Address { get; private set; }
}

public class NewAddress
{
    private NewAddress()
    {
        
    }
    
    public string Street { get; private set; }
    public int Number { get; private set; }
}