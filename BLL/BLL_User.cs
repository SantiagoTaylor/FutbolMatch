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

        public static bool SaveUser(BE_User user)
        {
            return DAL_User.SaveUser(user);
        }

        public static bool UpdateUser(BE_User user)
        {
            return DAL_User.UpdateUser(user);
        }
    }
}
