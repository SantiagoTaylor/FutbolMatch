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
        public static bool DeleteEmployee(string id)
        {
            return DAL_Employee.DeleteEmployee(id);
        }

        public static BE_Employee GetEmployee(string id)
        {
            return DAL_Employee.GetEmployee(id);
        }

        public static DataTable GetEmployees()
        {
            DataTable dt = DAL_Employee.GetEmployees();
            return dt;
        }
        public static bool SaveEmployee(BE_Employee emp)
        {
            return DAL_Employee.SaveEmployee(emp);
        }

        public static bool UpdateEmployee(string id, BE_Employee emp)
        {
            return DAL_Employee.UpdateEmployee(id,emp);
        }
    }
}
