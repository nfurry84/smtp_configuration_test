using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyLib;

namespace MyLibService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        Timer serviceTimer = null;

        protected override void OnStart(string[] args)
        {
            new MyLib.EmailSender().SendEmail("Service Started", "The MyLibService has started successfully.");
            serviceTimer = new Timer(OnTimerElapsed, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));

        }

        TimerCallback OnTimerElapsed = (state) =>
        {
            try
            {
                // Write a periodic log entry to Log.txt in the service's base directory
                string logPath = AppDomain.CurrentDomain.BaseDirectory + "Log.txt";
                string logEntry = $"{DateTime.Now:u} - Periodic task executed by MyLibService.{Environment.NewLine}";
                System.IO.File.AppendAllText(logPath, logEntry);
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                EventLog.WriteEntry("MyLibService", ex.ToString(), EventLogEntryType.Error);
            }
        };

        protected override void OnStop()
        {
            new MyLib.EmailSender().SendEmail("Service Stopped", "The MyLibService was stopped.");
        }
    }
}
