using System.Collections;
using MessagePack;
using RabbitMessages;
using RabbitMQ.Client;

namespace RabbitPublisher;

public class PersonList : IEnumerable<Person>
{
    private List<Person> _persons;
    private IModel _channel; 
    public PersonList(IModel channel)
    {
        _persons = new List<Person>();
        _channel = channel;
        _channel.ExchangeDeclare("ListApp", ExchangeType.Topic);
        _channel.QueueDeclare(nameof(PersonAddedEvent), false, false, false);
        _channel.QueueDeclare(nameof(PersonDeletedEvent), false, false, false);
        _channel.QueueBind(nameof(PersonAddedEvent),"ListApp", nameof(PersonAddedEvent));
        _channel.QueueBind(nameof(PersonDeletedEvent),"ListApp", nameof(PersonDeletedEvent));
    }

    public void Add(string name, string family)
    {
        var item = new Person { Name = name, Family = family};
        _persons.Add(item);

        var _event = new PersonAddedEvent(name, family);
        _channel.BasicPublish("ListApp",nameof(PersonAddedEvent), true, null,  MessagePackSerializer.Serialize(_event));
      
    }

    public bool Delete(string name, string family)
    {
        var item = _persons.FirstOrDefault(x => x.Name == name.Trim() && x.Family == family.Trim());
        if (item == null)
        {
            return false;
        }

        _persons.Remove(item);
        var _event = new PersonDeletedEvent(name, family);
        _channel.BasicPublish("ListApp",nameof(PersonDeletedEvent), true, null,  MessagePackSerializer.Serialize(_event));
        return true;
    }

    public IEnumerator<Person> GetEnumerator()
    {
        return this._persons.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}