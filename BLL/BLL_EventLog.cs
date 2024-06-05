using BE;
using DAL;
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
        public static void RegisterEventLog()
        {
            //FALTA CREAR BE EVENT LOG Y LOS PARAMETROS DE ESTE METODO
            //BE_EventLog eventLog = new BE_EventLog();
            //DAL_EventLog.RegisterEventLog(eventLog);
        }

        public static DataTable TraerBitacora()
        {
            return DAL_EventLog.GetEventLog();
        }

        public static DataTable GetActivityLevel()
        {
            return DAL_EventLog.GetActivityLevel();
        }
    }
}
