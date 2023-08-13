// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;

var connectionFactory = new ConnectionFactory();
connectionFactory.Endpoint = new AmqpTcpEndpoint("localhost", 5672);
connectionFactory.UserName = "user";
connectionFactory.Password = "password";
connectionFactory.ClientProvidedName = "publisher";
var connection = connectionFactory.CreateConnection();
var channel = connection.CreateModel();
channel.ExchangeDeclare("test-exchange", ExchangeType.Topic);
//channel.QueueDeclare("my-queue", true,false,false);
//channel.QueueBind("my-queue", "test-exchange", "route" );
var message = "";


var randomMessage = new Dictionary<string, List<string>>()
{
    {"Alborz" ,new List<string>{"Damavand", "Alvand","Neyzava", "Binalood","Sahand"}},
    {"Zagros" ,new List<string>{"KarkasKooh",  "Chary", "BelKooh","AlamKooh"}},
    {"Markazi", new List<string>{ "Taftan", "Sabalan", "Shirkooh"}}
};
var keys = randomMessage.Keys.Select(x=>x).ToArray();
var r = new Random();
while (true)
{
    var key = keys[r.Next(3)];
    var items = randomMessage[key];
    message = items[r.Next(items.Count - 1)];
    await Task.Run(()=>channel.BasicPublish("test-exchange" ,key,null, System.Text.Encoding.UTF8.GetBytes(message)));
    Thread.Sleep(2000);
    Console.WriteLine($"{message} has been sent to route {key}");
}

Console.WriteLine("Hello, World!");