using System.Collections.ObjectModel;

namespace EventLogBrowser
{
    public class EventLogs
    {
        public string LogName { get; set; }

        public ObservableCollection<Event> Events { get; set; }
    }
}
