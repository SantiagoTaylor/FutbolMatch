using DAL;
using SERVICES;
using System;
using System.Data;

namespace BLL
{
    public class BLL_Login
    {
        public static DataTable GetUsers()
        {
            return DAL_Login.GetUsers();
        }

        public static bool IsValidCredentials(string user, string password)
        {
            string encyptedPassword = Encrpyt.HashPassword(password);
            if (DAL_Login.UserExist(user, encyptedPassword))
            {
                SessionManager.Login(DAL_Login.GetUserByUsername(user));
                //DAR PERMISOS
                //REGISTRAR BITACORA
                return true;
            }
            return false;
        }
    }
}
