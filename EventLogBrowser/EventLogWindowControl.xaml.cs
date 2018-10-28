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

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "EventLogWindow");
        }

        // TODO: Delete this, leaving for debugging reasons
        private List<EventLogFolder> GetEventLogFolders()
        {
            var systemLogs = new EventLogs()
            {
                LogName = "System",
                Events = new List<Event>()
                {
                    new Event
                    {
                        Level = "Error1",
                        DateAndTime = DateTime.Now,
                        EventSource = "Application1",
                        Message = "Error Message1"
                    },
                    new Event
                    {
                        Level = "Error2",
                        DateAndTime = DateTime.Now,
                        EventSource = "Application2",
                        Message = "Error Message2"
                    }
                }
            };

            var applicationLogs = new EventLogs()
            {
                LogName = "Application",
                Events = new List<Event>()
                {
                    new Event
                    {
                        Level = "Error3",
                        DateAndTime = DateTime.Now,
                        EventSource = "Application3",
                        Message = "Error Message3"
                    },
                    new Event
                    {
                        Level = "Error4",
                        DateAndTime = DateTime.Now,
                        EventSource = "Application4",
                        Message = "Error Message4"
                    }
                }
            };

            var hardwareEventLogs = new EventLogs()
            {
                LogName = "Hardware",
                Events = new List<Event>()
                {
                    new Event
                    {
                        Level = "Error5",
                        DateAndTime = DateTime.Now,
                        EventSource = "Application5",
                        Message = "Error Message5"
                    },
                    new Event
                    {
                        Level = "Error6",
                        DateAndTime = DateTime.Now,
                        EventSource = "Application5",
                        Message = "Error Message6"
                    }
                }
            };

            var eventLogs = new List<EventLogs> { systemLogs, applicationLogs };
            var appAndSvcLogs = new List<EventLogs> { hardwareEventLogs };

            var windowsLogsFolder = new EventLogFolder()
            {
                FolderName = "Windows Logs",
                EventLogs = eventLogs
            };

            var appAndSvcLogsFolder = new EventLogFolder()
            {
                FolderName = "Apps and Svcs Logs",
                EventLogs = appAndSvcLogs
            };

            var folders = new List<EventLogFolder> { windowsLogsFolder, appAndSvcLogsFolder };

            return folders;
        }
    }
}