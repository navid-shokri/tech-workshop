using System;
using System.Threading.Tasks;
using Enexure.MicroBus;

namespace Mediatorsss;

public class PingHandler : IMessageHandler<Ping,int>
{

    public Task<int> Handle(Ping message)
    {
        Console.WriteLine("Ping arrived!!!");
        return Task.FromResult(1);
    }
}