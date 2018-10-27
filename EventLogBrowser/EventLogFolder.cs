using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogBrowser
{
    public class EventLogFolder
    {
        public string Path { get; set; }

        public string FolderName { get; set; }

        public List<EventLog> EventLogs { get; set; }
    }
}
