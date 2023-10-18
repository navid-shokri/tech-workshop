// See https://aka.ms/new-console-template for more information

using EasyNetQ;
using Message;
using Server;

Console.WriteLine("Hello, World!");

var bus = RabbitHutch.CreateBus("username=user;password=password;virtualHost=/;host=localhost:5672");
var lw = new ListenerWrapper(bus);
var w = new Worker();
await lw.RegisterReceiveAsync<Command>("my.command", async (command, token) => await w.HandleCommand(command, token));
Console.WriteLine("Listening to commands. press enter to exit...");
Console.ReadLine();