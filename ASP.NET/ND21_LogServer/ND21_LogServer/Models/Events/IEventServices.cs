using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND21_LogServer.Models.Events
{
    public interface IEventServices
    {
        IEnumerable<ExtendedEvent> GetEvents(DateTime fromDate, DateTime toDate, int projectID, bool errorsOnly);
    }
}
