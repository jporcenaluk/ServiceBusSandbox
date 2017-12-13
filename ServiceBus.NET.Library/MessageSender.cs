using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.NET.Library
{
    public class MessageSender : MessageClient
    {

        public async Task<string> SendMessage(string messageBody)
        {
            IQueueClient queueClient = new QueueClient(ServiceBusConnectionString, QueueName);


            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            Console.WriteLine($"Sending message: {messageBody}");

            await queueClient.SendAsync(message);

            await queueClient.CloseAsync();

            //TODO: Richer response
            return "Message Sent Successfully";
        }
    }
}
