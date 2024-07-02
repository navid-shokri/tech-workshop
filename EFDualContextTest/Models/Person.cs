namespace EFDualContextTest.Models;

public class Person : BaseEntity
{
    protected Person()
    {
    }

    public Person(string name, string family)
    {
        Name = name;
        Family = family;
        
    }

    public void SetPersonalInfo(string name, string family )
    {
        Name = name;
        Family = family;
    }

    public void AddOrder(Order order)
    {
        _orders.Add(order);
        order.SetOwner(this);
        _histories.Add(new History(this,$@"{order.TotalPrice} added Anagha"));
    }

    public void RemoveOrder(Guid id)
    {
        var item = Orders.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            _orders.Remove(item);
            _histories.Add(new History(this, $"{item.TotalPrice} removed Anagha"));
        }

    }
    
    protected override void Validate()
    {
        
    }

    public void SetAddress(string city, string street)
    {
        Address = new Address(city, street);
        AddHistory(new History(this,$"Address added"));
    }

    public Address Address { get; set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    private List<History> _histories = new List<History>();

    private List<Order> _orders = new List<Order>();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
    public IReadOnlyCollection<History> Histories => _histories.AsReadOnly();

    public void AddHistory(History history)
    {
        _histories.Add(history);
    }

}