using ND21_LogServer.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND21_LogServer.Models.Log
{
    public interface ILogServices
    {
        bool AppendEvent(Event ev);
        bool AppendEvent(IEnumerable<Event> events);
    }
}
