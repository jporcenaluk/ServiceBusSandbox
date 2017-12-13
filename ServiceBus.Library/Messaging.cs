using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ServiceBus;

namespace ServiceBus.REST.Library
{
    public class Messaging
    {
        private string SubscriptionID { get; set; }
        private string ResourceGroupName { get; set; }
        private string NamespaceName { get; set; }
        private string QueueName { get; set; }
        private string ApiVersion { get; set; }
        private string BaseUrl { get; set; }

        public Messaging()
        {
            BaseUrl = "https://management.azure.com";
        }

        private string GetQueue()
        {
         

            var url = String.Format("{0}/subscriptions/{1}/resourceGroups/{2}/providers/Microsoft.ServiceBus/namespaces/{3}/queues/{4}?api-version={5}",
                BaseUrl, SubscriptionID, ResourceGroupName, NamespaceName, QueueName, ApiVersion);


            return "Not Implemented";
        }
        
    }
}
