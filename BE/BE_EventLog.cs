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

        public string Username { get => _username; set => _username = value; }
        public string Activity { get => _activity; set => _activity = value; }
        public DateTime EventDate { get => _eventDate; set => _eventDate = value; }
        public TimeSpan EventTime { get => _eventTime; set => _eventTime = value; }

        public BE_EventLog(string username, string activity, string message)
        {
            _username = username;
            _activity = activity;
            _eventDate = DateTime.Now;
            _eventTime = DateTime.Now.TimeOfDay;
        }
    }
}
