﻿// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitPublisher;

var connectionFactory = new ConnectionFactory();
connectionFactory.Endpoint = new AmqpTcpEndpoint("192.168.200.162", 5672);
connectionFactory.UserName = "staging";
connectionFactory.Password = "staging";
connectionFactory.VirtualHost = "staging";
connectionFactory.ClientProvidedName = "publisher";
var connection = connectionFactory.CreateConnection();
var channel = connection.CreateModel();
channel.ExchangeDeclare("test-exchange", ExchangeType.Topic);

var list  = new PersonList(channel);
var ioManager = new ConsoleIoManager(list);
var command = "";
while (command != "QUIT")
{
    Console.WriteLine("enter your command: (A: Add, D: Delete, L: list)");
    command = Console.ReadLine();
    ioManager.HandleCommand(command);
    
}

Console.WriteLine("Publisher shut down");