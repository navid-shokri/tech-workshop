using EasyNetQ;
using Message;

namespace Server;

public class ListenerWrapper
{
    private readonly IBus _bus;

    public ListenerWrapper(IBus bus)
    {
        _bus = bus;
    }

    public async Task RegisterReceiveAsync()
    {
        await _bus.Rpc.RespondAsync<Command,Result>((command, cancellationToken) =>
        {
            if (command.Id % 3 == 0)
            {
                throw new Exception("Opppssss!!!");
            }

            return Task.FromResult(new Result { Data = $"{command.Name}|{command.Family}|{command.Id}" });
        }, 
            config =>
        {
            config.WithQueueName(nameof(Command));
        });
    }
}