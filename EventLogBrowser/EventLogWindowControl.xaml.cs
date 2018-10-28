namespace EventLogBrowser
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for EventLogWindowControl.
    /// </summary>
    public partial class EventLogWindowControl : UserControl
    {
        private EventLogService eventLogService;
        private List<EventLogs> eventLogs;

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
                EventLogs = this.eventLogs
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
            this.eventLogs = eventLogService.GetEventLogs();
        }
    }
}