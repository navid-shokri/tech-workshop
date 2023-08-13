// See https://aka.ms/new-console-template for more information

using System.Net.Mime;
using MessagePack;
using RabbitMessages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var connectionFactory = new ConnectionFactory();
connectionFactory.Endpoint = new AmqpTcpEndpoint("localhost", 5672);
connectionFactory.UserName = "user";
connectionFactory.Password = "password";
connectionFactory.ClientProvidedName = $"subscriber";
connectionFactory.DispatchConsumersAsync = true;
var connection = connectionFactory.CreateConnection();
var channel = connection.CreateModel();

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.Received += async (ch, ea) =>
{
    Console.WriteLine("add handler");
    var body = ea.Body.ToArray();
    var msg = MessagePackSerializer.Deserialize<PersonAddedEvent>(body);
    Console.WriteLine($"{msg.Name} {msg.Family} added to list.");
    //channel.BasicAck(ea.DeliveryTag, false);
};

var consumer2 = new AsyncEventingBasicConsumer(channel);
consumer2.Received += async (ch, ea) =>
{
    Console.WriteLine("delete handler");
    var body = ea.Body.ToArray();
    var msg = MessagePackSerializer.Deserialize<PersonDeletedEvent>(body);
    Console.WriteLine($"{msg.Name} {msg.Family} removed from list.");
    channel.BasicAck(ea.DeliveryTag, false);
};
// this consumer tag identifies the subscription
// when it has to be cancelled
string consumerTag = channel.BasicConsume(nameof(PersonAddedEvent), false, consumer);

string consumerTag2 = channel.BasicConsume(nameof(PersonDeletedEvent), false, consumer2);

/*var consumer = new MyClass();

    var message = channel.BasicConsume("my-queue", true, "consumer", consumer);
    Console.WriteLine($"{message} has been received, It gas {message.Length} chars");
    Thread.Sleep(100);*/
Console.ReadLine();

Console.WriteLine("Hello, World!");


