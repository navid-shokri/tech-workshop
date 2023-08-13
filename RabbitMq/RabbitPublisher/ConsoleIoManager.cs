using RabbitMQ.Client;

namespace RabbitPublisher;

public class ConsoleIoManager
{
    private readonly PersonList _list;
   

    public ConsoleIoManager(PersonList personList)
    {
        _list = personList;
    }

    public void HandleCommand(string command)
    {
        switch (command)
        {
                case "A" or "a" :
                    this.AddPerson();
                    break;
                case  "D" or "d":
                    this.DeletePerson();
                    break;
                case "L" or "l" :
                    this.ListPersons();
                    break;
                default: 
                    Console.WriteLine("Wrong answer!!!");
                    break;
                    
        }
    }


    protected void AddPerson()
    {
        Console.WriteLine("Enter name:");
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Enter family:");
        var family = Console.ReadLine();
        
        _list.Add(name, family);
    }
    
    protected void DeletePerson()
    {
        Console.WriteLine("Enter name:");
        var name = Console.ReadLine(); 
        
        Console.WriteLine("Enter family:");
        var family = Console.ReadLine();
        
        var success  = _list.Delete(name, family);
        if (!success)
        {
            Console.WriteLine("There is no such item!");
        }
    }

    protected void ListPersons()
    {
        var i = 0;
        foreach (var item in _list) 
        {
            
            Console.WriteLine($"#{++i}: {item.Name} {item.Family}");
        }
    }

}