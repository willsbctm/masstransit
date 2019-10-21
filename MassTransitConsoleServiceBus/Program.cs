using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitConsoleServiceBus
{
    class Program
    {
        const string ServiceBusConnectionString = "Endpoint=sb://will-sb-l3.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=u2eK55KmHAVzZqF8gHGJj5Q3NNlbsmcuGdHcU7PzbDk=";
        const string TopicName = "topiccontract";
        static ITopicClient topicClient;

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            Console.WriteLine("======================================================");
            Console.WriteLine("Press any key to exit after receiving all the messages.");
            Console.WriteLine("======================================================");

            await SendMessagesAsync();

            Console.ReadKey();

            await topicClient.CloseAsync();
        }

        static async Task SendMessagesAsync()
        {
            try
            {
                do
                {
                    Console.WriteLine("Enter message (or quit to exit)");
                    Console.Write("> ");
                    string value = Console.ReadLine();

                    if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                        break;

                    var messageBody = $@"{{
                         ""messageType"": [
                           ""urn:message:MassTransiteContracts:IContrato""
                         ],
                         ""message"": {{
                           ""Nome"": ""{value}""
                         }},
                         ""headers"": {{}}
                    }}";

                    var message = new Message(Encoding.UTF8.GetBytes(messageBody))
                    {
                        ContentType = "application/vnd.masstransit+json",
                        CorrelationId = Guid.NewGuid().ToString(),
                        MessageId = Guid.NewGuid().ToString()
                    };

                    Console.WriteLine($"Sending message: {messageBody}");

                    await topicClient.SendAsync(message);
                }
                while (true);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}
