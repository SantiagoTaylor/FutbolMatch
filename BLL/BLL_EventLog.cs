using BE;
using DAL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class BLL_EventLog
    {
        public static void RegisterEventLog(string username, string activity)
        {
            //HACE FALTA CREARLO ACA??? O ANTES??? USERNAME -> SESSION MANAGER ¿?desde BE???
            BE_EventLog eventlog = new BE_EventLog(username, activity);
            int idEventLog = DAL_EventLog.RegisterEventLog(eventlog);
            BLL_DV_EventLog.InsertDV(idEventLog);
        }

        public static DataTable GetEventLog()
        {
            return DAL_EventLog.GetEventLog(SessionManager.GetInstance.User.Language);
        }

        public static object GetActivityLevels()
        {
            return DAL_EventLog.GetActivityLevels(SessionManager.GetInstance.User.Language);
        }

        public static object GetActivitys()
        {
            return DAL_EventLog.GetActivitys(SessionManager.GetInstance.User.Language);
        }
    }
}
