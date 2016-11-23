using ND21_LogServer.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ND21_LogServer.Models.Log
{
    public class EventWrapper
    {
        public Guid APIKey { get; set; }
        public Event[] Events { get; set; }
    }
}