using NEventStore;

namespace ErrorHandeling;

public class EventStoreHandler
{
    private readonly IStoreEvents _storeEvents;

    public EventStoreHandler(IStoreEvents storeEvents)
    {
        _storeEvents = storeEvents;
    }
    public void Store()
    {
        using (var stream = _storeEvents.CreateStream(streamId:"tests"))
        {
            stream.Add(new EventMessage{Body = "test mikonam"});
            stream.CommitChanges(Guid.NewGuid());
        }
    }
}