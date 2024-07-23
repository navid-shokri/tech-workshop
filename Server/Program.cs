// See https://aka.ms/new-console-template for more information

using EasyNetQ;
using EasyNetQ.Consumer;
using EasyNetQ.DI;
using Server;

Console.WriteLine("Hello, World!");

var bus = RabbitHutch.CreateBus("username=user;password=password;virtualHost=/;host=127.0.0.1:5672",
    register =>
    {
        //register.EnableConsoleLogger();
        register.Register<IConsumerErrorStrategy,LoggerErrorStrategy>();
    });
var lw = new ListenerWrapper(bus);
var bg = new MyBackgroundWorker(lw);
await bg.StartAsync(CancellationToken.None);
Console.WriteLine("Listening to commands. press enter to exit...");
Console.ReadLine();