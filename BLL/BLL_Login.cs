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
                //DAR PERMISOS
                //REGISTRAR BITACORA
                return true;
            }
            return false;
        }
    }
}
