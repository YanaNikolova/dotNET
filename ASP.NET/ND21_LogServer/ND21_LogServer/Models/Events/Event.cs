using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ND21_LogServer.Models.Events
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public string Message { get; set; }
        public Guid ApiKey { get; set; }
    }
}