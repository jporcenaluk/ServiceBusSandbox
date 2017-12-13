using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;

namespace ServiceBus.NET.Library
{
    public class Messaging
    {
        const string ServiceBusConnectionString = "Endpoint=sb://taxslayertest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=bGbZ1lXAI7FCjmyYusoeP++g1SLT0AQA/zkWSci5Lp8=";
        const string QueueName = "testqueue";
        static IQueueClient queueClient;

        public Messaging()
        {

        }

        public async Task<string> SendMessage(string messageBody)
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);


            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            Console.WriteLine($"Sending message: {messageBody}");

            await queueClient.SendAsync(message);

            await queueClient.CloseAsync();

            //TODO: Richer response
            return "Message Sent Successfully";
        }

        //TODO: Receive messages, allow subscription of

    }
}
