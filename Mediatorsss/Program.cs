// See https://aka.ms/new-console-template for more information
using System;
using Enexure.MicroBus;
using Enexure.MicroBus.MicrosoftDependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mediatorsss
{


    public class Mediatoree
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Hello, World!");
                /*var busBuilder = new BusBuilder()
                    .RegisterMessage(new HandlerRegistration(typeof(TempChanged), typeof(TempChangeHandler)))
                    .RegisterMessage(new HandlerRegistration(typeof(Ping), typeof(PingHandler)));
                
                    */
                    //.RegisterMessage(new HandlerRegistration(typeof(Ping), typeof(PingZnotherHandler)));
                var serviceCollection = new ServiceCollection().AddMediatR(configuration =>
                {
                }).BuildServiceProvider();
                //.AddMediator().BuildServiceProvider();
                    
                var serviceBus = serviceCollection.GetRequiredService<IMediator>();
                Console.WriteLine("Enter a number:");
                var answer = Console.ReadLine();
                while (answer != "q")
                {
                    serviceBus.Publish(new Ping()).GetAwaiter().GetResult();
                    serviceBus.Send(new Ping()).GetAwaiter().GetResult();
                    serviceBus.Publish(new TempChanged
                    {
                        NewValue = Random.Shared.Next(1,100),
                        OldValue = Random.Shared.Next(1,100),
                    }).GetAwaiter().GetResult();
                    Console.WriteLine("Enter a number:");
                    answer = Console.ReadLine();
                    

                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}