using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogBrowser
{
    public class EventLogFolder
    {
        public string FolderName { get; set; }

        public List<EventLogs> EventLogs { get; set; }
    }
}
