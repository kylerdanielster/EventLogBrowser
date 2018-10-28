using System;

namespace EventLogBrowser
{
    public class Event
    {
        public string Level { get; set; }

        public DateTime DateAndTime { get; set; }

        public string EventSource { get; set; }

        public string Message { get; set; }
    }
}
