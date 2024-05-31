using DAL;
using SERVICES;

namespace BLL
{
    public class BLL_Login
    {
        public static bool IsValidCredentials(string user, string password)
        {
            string encyptedPassword = Encrpyt.HashPassword(password);
            if (DAL_Login.UserExist(user, encyptedPassword))
            {
                //hacer cosas
                return true;
            }
            return false;
        }
    }
}
