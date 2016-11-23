using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ND21_LogServer.Conversion
{
    public class EventType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private EventType(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public static readonly EventType Info = new EventType(1, "Information");
        public static readonly EventType Error = new EventType(2, "Error");
        public static readonly EventType Msg = new EventType(3, "Message");

        public static EventType Resolve(int id)
        {
            switch (id)
            {
                case 1: return Info;
                case 2: return Error;
                case 3: return Msg;
                default: return Msg;
            }
        }
    }
}