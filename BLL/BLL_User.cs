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

        public static bool BlockUser(string username)
        {
            return DAL_User.BlockUser(username);
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
            if (DAL_User.InsertUser(user))// si todo ok:
            {
                BLL_DV_User.InsertDV(user.Username);
                //EVENT LOG
                return true;
            }
            return false;
        }

        public static bool UpdateUser(BE_User user)
        {
            if (DAL_User.UpdateUser(user))// si todo ok:
            {
                BLL_DV_User.UpdateDV(user.Username);
                return true;
            }
            return false;
        }

        public static void UpdateMyAccount(BE_User user)
        {
            DAL_User.UpdateMyAccount(user);
        }
    }
}
