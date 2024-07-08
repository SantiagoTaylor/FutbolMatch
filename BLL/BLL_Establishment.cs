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
    }
}
