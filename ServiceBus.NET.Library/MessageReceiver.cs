using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;
using System.Threading;

namespace ServiceBus.NET.Library
{
    public class MessageReceiver : MessageClient
    {
        public delegate void MessageReceivedEventHandler(object source, MessageEventArgs args);
        public event MessageReceivedEventHandler MessageReceived;

        static IQueueClient MessageReceivedClient;


        public MessageReceiver()
        {
            MessageReceivedClient = new QueueClient(ServiceBusConnectionString, QueueName);
            RegisterOnMessageHandlerAndReceiveMessages();


        }

        void RegisterOnMessageHandlerAndReceiveMessages()
        {
            // Configure the message handler options in terms of exception handling, number of concurrent messages to deliver, etc.
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            MessageReceivedClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }

        async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            // Process the message.
            string messageBody = Encoding.UTF8.GetString(message.Body);
            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{messageBody}");

            // Complete the message so that it is not received again.
            // This can be done only if the queue Client is created in ReceiveMode.PeekLock mode (which is the default).
            await MessageReceivedClient.CompleteAsync(message.SystemProperties.LockToken);
            OnMessageReceived(messageBody);
            // Note: Use the cancellationToken passed as necessary to determine if the queueClient has already been closed.
            // If queueClient has already been closed, you can choose to not call CompleteAsync() or AbandonAsync() etc.
            // to avoid unnecessary exceptions.
        }

        protected virtual void OnMessageReceived(string messageBody)
        {
            var messageEventArgs = new MessageEventArgs
            {
                MessageBody = messageBody
            };
            MessageReceived?.Invoke(this, messageEventArgs);
        }
    }

    public class MessageEventArgs: EventArgs
    {
        public string MessageBody { get; set; }
    }
}
