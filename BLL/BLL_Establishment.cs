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
    public static class BLL_Establishment
    {
        public static string GetEstablishment(string username)
        {
            return DAL_Establishment.GetEstablishment(username);
        }

        public static DataTable GetEstablishments()
        {
            return DAL_Establishment.GetEstablishments();
        }

        public static DataTable GetUserEstablishments(BE_User user)
        {
            return DAL_Establishment.GetUserEstablishments(user);
        }

        public static bool RegisterEstablishment(BE_Establishment s)
        {
            return DAL_Establishment.RegisterEstablishment(s);
        }

        public static bool SetUserEstablishment(string user, string establishmentName)
        {
            return DAL_Establishment.SetUserEstablishment(user, establishmentName);
        }
    }
}
