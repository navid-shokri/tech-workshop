using System;
using System.Threading;
using System.Threading.Tasks;
using Enexure.MicroBus;

namespace Mediatorsss;

public class PingZnotherHandler : IMessageHandler<Ping, int>
{
    public ValueTask Handle(Ping notification, CancellationToken cancellationToken)
    {
        
        return new ValueTask();
    }

    public Task<int> Handle(Ping message)
    {
        Console.WriteLine("Me too, Ping, Mee Too!!!");
        return Task.FromResult(1);
    }
}