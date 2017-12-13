using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.NET.Library
{
    public abstract class MessageClient
    {
        internal string ServiceBusConnectionString => "Endpoint=sb://taxslayertest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=bGbZ1lXAI7FCjmyYusoeP++g1SLT0AQA/zkWSci5Lp8=";
        internal string QueueName => "testqueue";
    }
}
