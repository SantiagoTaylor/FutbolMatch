﻿using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLL_DV_EventLog
    {
        public static void InsertDV(int idEventlog)
        {
            DataTable table = DAL_DV_EventLog.HashedRowEventLog(idEventlog);
            DAL_DV_EventLog.InsertDV(table);
        }
    }
}
