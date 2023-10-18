using EasyNetQ;

namespace Server;

public class ListenerWrapper
{
    private readonly IBus _bus;

    public ListenerWrapper(IBus bus)
    {
        _bus = bus;
    }

    public Task RegisterReceiveAsync<T>(string queueName, Func<T, CancellationToken, Task> handler)
    {
        return _bus.SendReceive.ReceiveAsync("my.command", registration =>
            registration.Add<T>(async (command, cancellationToken) =>
            {
                await handler(command, cancellationToken);
            })
        );
    }
}