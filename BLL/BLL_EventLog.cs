using BE;
using DAL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_EventLog
    {
        public static void RegisterEventLog(string username, string activity)
        {
            //HACE FALTA CREARLO ACA??? O ANTES??? USERNAME -> SESSION MANAGER ¿?desde BE???
            BE_EventLog eventlog = new BE_EventLog(username, activity);
            DAL_EventLog.RegisterEventLog(eventlog);
        }

        public static DataTable GetEventLog()
        {
            return DAL_EventLog.GetEventLog(SessionManager.GetInstance.User.Language);
        }

        public static DataTable GetActivityLevel()
        {
            return DAL_EventLog.GetActivityLevel();
        }
    }
}
