using System.Text;
using EasyNetQ.Consumer;

namespace Server;

public class LoggerErrorStrategy: IConsumerErrorStrategy
{
    public void Dispose()
    {
        
    }

    public Task<AckStrategy> HandleConsumerErrorAsync(ConsumerExecutionContext context, Exception exception,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var o = Encoding.UTF8.GetString(context.Body.ToArray());
        Console.WriteLine("Body: " + o);
        var t = exception.Message;
        Console.WriteLine("msg: "+ t);
        return Task.FromResult(AckStrategies.Ack);
    }

    public Task<AckStrategy> HandleConsumerCancelledAsync(ConsumerExecutionContext context,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.FromResult(AckStrategies.NackWithoutRequeue);
    }
}