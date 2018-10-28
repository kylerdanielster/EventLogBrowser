using System.Diagnostics;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="EventLogWindowControl"/> class.
        /// </summary>
        public EventLogWindowControl()
        {
            this.InitializeComponent();

            this.eventLogService = new EventLogService();

            var eventLogs = eventLogService.GetEventLogs();

            this.DataContext = new
            {
                EventLogs = eventLogs
            };
        }

        private void StackPanel_MouseDown(object sender, RoutedEventArgs e)
        {
            var eventMessage = ((StackPanel)sender).Tag.ToString();

            EventMessageText.Text = eventMessage;
        }

        private void Refresh_Logs_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Refresh Logs");
            this.DataContext = new
            {
                EventLogs = eventLogService.GetEventLogs()
            };
        }
    }
}