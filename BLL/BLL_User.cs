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
    public class BLL_User
    {
        public static bool DeleteUser(string username)
        {
            return DAL_User.DeleteUser(username);
        }

        public static BE_User GetUserByUsername(string username)
        {
            return DAL_User.GetUserByUsername(username);
        }

        public static DataTable GetUsers()
        {
            return DAL_User.GetUsers();
        }

        public static bool InsertUser(BE_User user)
        {
            bool result = DAL_User.InsertUser(user);
            if (result)
            {
                DatabaseIntegrity.InsertDV(user.Username);
            }
            return result;
        }

        public static bool UpdateUser(BE_User user)
        {
            bool result = DAL_User.UpdateUser(user);
            if (result)
            {
                DatabaseIntegrity.UpdateDV(user.Username);
            }
            return result;
        }
    }
}
