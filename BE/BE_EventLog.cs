using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_EventLog
    {
        private string _username;
        private string _activity;
        private DateTime _eventDate;
        private TimeSpan _eventTime;

        public string Username { get => _username; }
        public string Activity { get => _activity; }
        public DateTime EventDate { get => _eventDate; }
        public TimeSpan EventTime { get => _eventTime; }

        public BE_EventLog(string username, string activity)
        {
            _username = username;
            _activity = activity;
            _eventDate = DateTime.Now;
            _eventTime = DateTime.Now.TimeOfDay;
        }
    }
}
