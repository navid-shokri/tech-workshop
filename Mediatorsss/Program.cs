// See https://aka.ms/new-console-template for more information
using System;
using Mediator;
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
                var serviceCollection = new ServiceCollection().AddMediator().BuildServiceProvider();

                var serviceBus = serviceCollection.GetRequiredService<IMediator>();
                Console.WriteLine("Enter a number:");
                var answer = Console.ReadLine();
                while (answer != "q")
                {
                    serviceBus.Publish(new Ping());
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