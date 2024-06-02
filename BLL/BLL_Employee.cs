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
    public class BLL_Employee
    {
        public static DataTable GetEmployees()
        {
            DataTable dt = DAL_Employee.GetEmployees();
            dt.Columns.Remove("idEmploye");
            dt.Columns.Remove("password");
            return dt;
        }
        public static bool SaveEmployee(BE_Employee emp)
        {
            return DAL_Employee.SaveEmployee(emp);
        }
    }
}
