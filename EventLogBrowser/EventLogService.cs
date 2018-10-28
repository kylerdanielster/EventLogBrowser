using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EventLogBrowser
{
    public class EventLogService
    {
        public List<EventLogs> GetEventLogs()
        {
            var eventLogs = new List<EventLogs>();
            EventLog[] logs = EventLog.GetEventLogs(Environment.MachineName);
            foreach (var log in logs)
            {
                try
                { 
                eventLogs.Add(new EventLogs
                {
                    LogName = log.LogDisplayName,
                    Events = GetEvents(log.Entries)
                });
                }
                catch(Exception e)
                {
                    //Debug.WriteLine("Exception:{0}", e.Message);
                }
            }

            return eventLogs;
        }

        private List<Event> GetEvents(EventLogEntryCollection entries)
        {
            var events = new List<Event>();
            EventLogEntry[] entriesArray = new EventLogEntry[entries.Count];

            entries.CopyTo(entriesArray, 0);

            var logs = entriesArray.OrderByDescending(e => e.TimeGenerated).Take(20).ToList();

            for(var i = 0; i < logs.Count; i++)
            {
                events.Add(new Event
                {
                    EventSource = logs[i].Source,
                    DateAndTime = logs[i].TimeGenerated,
                    Level = logs[i].EntryType.ToString(),
                    Message = logs[i].Message
                });
            }

            return events;
        }
    }
}
