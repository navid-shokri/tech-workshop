// See https://aka.ms/new-console-template for more information

using System.Transactions;
using EasyNetQ;
using Message;

Console.WriteLine("Hello, World!");
var bus = RabbitHutch.CreateBus("username=user;password=password;virtualHost=/;host=localhost:5672");
var exit = "";
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
    
}*/
int i = 0; 
while (i < 100)
{
    var command = new Command
    {
        Family = "test" + i ,
        Name = "test" + i 
    };
    await bus.SendReceive.SendAsync("my.command", command);

    await Task.Delay(2000);
    i++;

}