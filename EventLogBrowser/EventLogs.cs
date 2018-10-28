using System.Collections.Generic;

namespace EventLogBrowser
{
    public class EventLogs
    {
        public string LogName { get; set; }

        public List<Event> Events { get; set; }
    }
}
