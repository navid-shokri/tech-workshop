using System;
using System.Threading;
using System.Threading.Tasks;
using Mediator;

namespace Mediatorsss;

public class PingHandler : INotificationHandler<Ping>
{
    public ValueTask Handle(Ping notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Ping arrived!!!");
        return new ValueTask();
    }
}