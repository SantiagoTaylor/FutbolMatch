using DAL;
using SERVICES;
using System;
using System.Data;

namespace BLL
{
    public class BLL_Login
    {
        public static bool IsValidCredentials(string user, string password)
        {
            string encyptedPassword = Encrpyt.HashPassword(password);
            if (DAL_Login.UserExist(user, encyptedPassword))
            {
                SessionManager.Login(DAL_User.GetUserByUsername(user));
                BLL_EventLog.RegisterEventLog(SessionManager.GetInstance.User.Username, "Login");
                //DAR PERMISOS
                return true;
            }
            return false;
        }
    }
}
