using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLL_Role
    {
        public static DataTable GetRoles()
        {
            return DAL_Role.GetRoles();
        }
    }
}
