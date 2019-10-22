using MassTransit;
using MassTransit.Azure.ServiceBus.Core;
using MassTransiteContracts;
using System;
using System.Threading.Tasks;

namespace MassTransitConsole
{
    class Program
    {
        const string ServiceBusConnectionString = "";
        const string TopicName = "topiccontract";
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var bus = ConfigureBus();

            await bus.StartAsync();

            do
            {
                Console.WriteLine("Enter message (or quit to exit)");
                Console.Write("> ");
                string value = Console.ReadLine();

                if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                    break;

                await bus.Publish<IContrato>(new { Nome = value });
            }
            while (true);

            await bus.StopAsync();
        }

        static IBusControl ConfigureBus()
        {
            return AzureBusFactory.CreateUsingServiceBus(cfg =>
               {
                   cfg.Message<IContrato>(x => x.SetEntityName(TopicName));

                   var host = cfg.Host(ServiceBusConnectionString, h =>
                   {
                       h.RetryLimit = 3;
                       h.OperationTimeout = TimeSpan.FromSeconds(30);
                   });

                   cfg.ReceiveEndpoint("masstransitsender", c =>
                   {
                       EndpointConvention.Map<IContrato>(c.InputAddress);
                   });
               });
        }
    }
}
