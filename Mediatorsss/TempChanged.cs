using Enexure.MicroBus;
using Mediator;

namespace Mediatorsss;

public class TempChanged
{
    public int NewValue { get; set; }
    public int OldValue { get; set; }
}