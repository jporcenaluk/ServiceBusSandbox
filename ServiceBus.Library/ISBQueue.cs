using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceBus.RESTLibrary
{
    public interface ISBQueue
    {
        string ID { get; set; }
        DateTime AccessedAt { get; set; }
    }
}
