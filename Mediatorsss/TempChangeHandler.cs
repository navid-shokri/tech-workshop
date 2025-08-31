using System;
using System.Threading.Tasks;
using Enexure.MicroBus;
using MediatR;

namespace Mediatorsss;

public class TempChangeHandler : INotificationHandler<TempChanged>
{
    public Task<int> Handle(TempChanged message)
    {
        Console.WriteLine("Ay riom too Akhoond");
        return Task.FromResult(1);
    }
}