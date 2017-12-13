using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceBus.RESTLibrary
{
    public class SBQueue : ISBQueue
    {
        public string ID { get; set; }
        public DateTime AccessedAt { get; set; }
    }
}
