using System;
using System.Threading;
using System.Threading.Tasks;
using Mediator;

namespace Mediatorsss;

public class PingZnotherHandler : INotificationHandler<Ping>
{
    public ValueTask Handle(Ping notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Me too, Ping, Mee Too!!!");
        return new ValueTask();
    }
}