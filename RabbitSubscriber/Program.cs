// See https://aka.ms/new-console-template for more information

using System.Net.Mime;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var connectionFactory = new ConnectionFactory();
connectionFactory.Endpoint = new AmqpTcpEndpoint("localhost", 5672);
connectionFactory.UserName = "user";
connectionFactory.Password = "password";
connectionFactory.ClientProvidedName = $"subscriber-{args[0]}";
connectionFactory.DispatchConsumersAsync = true;
var connection = connectionFactory.CreateConnection();
var channel = connection.CreateModel();
var routes = new String[3];
if (args[0] == "1")
{
    routes = new[] { "Alborz", "Markazi" };
}
else
{
    routes = new[] { "Zagros", "Markazi" };
}

Console.WriteLine($"routes are: {String.Join(",", routes)}");
var consumer = new AsyncEventingBasicConsumer(channel);


var qname =channel.QueueDeclare().QueueName;
foreach (var route in routes)
{
    channel.QueueBind(qname,"test-exchange", route);
    Console.WriteLine($"{qname} bounded to {route}");
}

consumer.Received += async (ch, ea) =>
{
    var body = ea.Body.ToArray();
    var msg = System.Text.Encoding.UTF8.GetString(body);
    Console.WriteLine($"{msg} received, it was on  {ea.RoutingKey} ");
    channel.BasicAck(ea.DeliveryTag, false);
};
// this consumer tag identifies the subscription
// when it has to be cancelled
string consumerTag = channel.BasicConsume(qname, false, consumer);

/*var consumer = new MyClass();

    var message = channel.BasicConsume("my-queue", true, "consumer", consumer);
    Console.WriteLine($"{message} has been received, It gas {message.Length} chars");
    Thread.Sleep(100);*/
Console.ReadLine();

Console.WriteLine("Hello, World!");

class MyClass: DefaultBasicConsumer
{
    public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey,
        IBasicProperties properties, ReadOnlyMemory<byte> body)
    {
        base.HandleBasicDeliver(consumerTag, deliveryTag, redelivered, exchange, routingKey, properties, body);
    }
}
