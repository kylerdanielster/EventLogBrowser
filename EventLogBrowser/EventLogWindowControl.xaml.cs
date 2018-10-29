using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EventLogBrowser
{
    /// <summary>
    /// Interaction logic for EventLogWindowControl.
    /// </summary>
    public partial class EventLogWindowControl : UserControl
    {
        private EventLogService eventLogService;
        private ObservableCollection<EventLogs> eventLogs;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventLogWindowControl"/> class.
        /// </summary>
        public EventLogWindowControl()
        {
            this.InitializeComponent();

            this.eventLogService = new EventLogService();

            this.eventLogs = eventLogService.GetEventLogs();

            this.DataContext = new
            {
                EventLogs = eventLogs
            };
        }

        private void Event_Entry_MouseDown(object sender, RoutedEventArgs e)
        {
            var eventMessage = ((StackPanel)sender).Tag.ToString();

            EventMessageText.Text = eventMessage;
        }

        private void Refresh_Logs_Btn_Click(object sender, RoutedEventArgs e)
        {
            var newLogs = eventLogService.GetEventLogs();

            foreach (var log in newLogs)
            {
                var recentEvents = log.Events; // up to date events, will contain new events if any

                var logName = log.LogName; // current logs name
                
                var existingEvents = eventLogs.Where(l => l.LogName == logName).First().Events; // current logs events

                // the new events are the recent events that are not in the existing events
                var newEvents = recentEvents.Where(r => r.DateAndTime > existingEvents.First().DateAndTime).OrderBy(n => n.DateAndTime);

                // add each new event to the begining of the eventLogs
                foreach(var newEvent in newEvents)
                {
                    eventLogs.Where(l => l.LogName == logName).First().Events.Insert(0, newEvent);
                }
            }
        }
    }
}