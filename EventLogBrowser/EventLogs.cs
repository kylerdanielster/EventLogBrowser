﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventLogBrowser
{
    public class EventLogs
    {
        public string LogName { get; set; }

        public List<Event> Events { get; set; }
    }
}