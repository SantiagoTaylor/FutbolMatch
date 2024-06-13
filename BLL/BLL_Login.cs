using DAL;
using SERVICES;
using System;
using System.Web;
using System.Web.Security;

namespace BLL
{
    public class BLL_Login
    {
        public static bool IsValidCredentials(string user, string password)
        {
            string encyptedPassword = Encrpyt.HashValue(password);
            if (DAL_Login.UserExist(user, encyptedPassword))
            {
                SessionManager.Login(DAL_User.GetUserByUsername(user));
                BLL_EventLog.RegisterEventLog(SessionManager.GetInstance.User.Username, "Login");
                //DAR PERMISOS
                return true;
            }
            return false;
        }

        public static void Logout()
        {
            //try
            //{
            //    if (SessionManager.GetInstance != null)
            //    {
            //        BLL_EventLog.RegisterEventLog(SessionManager.GetInstance.User.Username, "Logout");
            //        SessionManager.Logout();
            //    }
            //}
            //catch (Exception)//manejar la excepcion
            //{
            //    throw;
            //}

            //EL CÓDIGO DE ARRIBA CUANDO IMPLEMENTE EL LOGOUT CON JS

            SessionManager.Logout();
        }
    }
}
