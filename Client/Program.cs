// See https://aka.ms/new-console-template for more information

using EasyNetQ;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SnappFood.Clays.ServiceBus.Abstractions;
using SnappFood.Clays.ServiceBus.EasyNetQ;
using SnappFood.Clays.ServiceBus.EasyNetQ.ServiceBus;
using JsonSerializer = System.Text.Json.JsonSerializer;

Console.WriteLine("Hello, World!");
var bus = RabbitHutch.CreateBus("username=user;password=password;virtualHost=/;host=127.0.0.1:5672");
var sampleBus = new SampleServiceBus(bus, NullLogger<EasyNetQServiceBus>.Instance);
var handler = new SampleHandler(bus, NullLogger<SampleHandler>.Instance);
var sampleListener =
    new SampleServiceBusListener(sampleBus, new[] { handler }, NullLogger<ServiceBusListenerBase>.Instance);

    await sampleListener.RegisterCustomConsumersAsync();
    await sampleListener.StartAsync(CancellationToken.None);
    Console.ReadKey();

/*while (true || exit.ToLower().StartsWith('y'))
{
    var command = new Command();
    Console.WriteLine("Enter Name:");
    command.Name = Console.ReadLine();
    Console.WriteLine("Enter Family:");
    command.Family = Console.ReadLine();

    await bus.SendReceive.SendAsync("my.command", command);
    
    Console.WriteLine("Exit?(y/N)");
    exit = Console.ReadLine();
    
}

}*/

class SampleServiceBus : EasyNetQServiceBus
{
    public SampleServiceBus(IBus bus, ILogger<EasyNetQServiceBus> logger) : base(bus, logger, "sample" )
    {
    }
}

class SampleServiceBusListener : ServiceBusListenerBase
{
    public SampleServiceBusListener(IServiceBus messageBus, IEnumerable<ICustomMessageHandler> handlers, ILogger<ServiceBusListenerBase> logger) : base(messageBus, handlers, logger)
    {
    }

    public override Task RegisterCommandHandlersAsync()
    {
        return Task.CompletedTask;
    }

    public override Task RegisterMessageReceiversAsync()
    {
        return Task.CompletedTask;
    }
}

class SampleHandler : LimitedRequeueHandler
{
    public SampleHandler(IBus serviceBus, ILogger<LimitedRequeueHandler> logger) : base(serviceBus, logger)
    {
    }

    protected override int GetRetryLimit() => 3;
    public override string GetExchangeName() => "test_retry";

    public override string GetExchangeType() => "x-delayed-message";

    public override string GetQueueName() => "test_retry_queue";

    public override Dictionary<string, object> GetMessageHeaders()
    {
        return new Dictionary<string, object>();
    }

    protected override async Task HandleIncomingMessageAsync(ReadOnlyMemory<byte> memory)
    {
        var memoryStream = new MemoryStream(memory.ToArray());
        var person  = await JsonSerializer.DeserializeAsync<Person>(memoryStream);
        throw new Exception("sample failed handler");
    }

    
}

public class Person
{
    public string Name { get; set; }
    public string Family { get; set; }
}