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
    public static class BLL_Field
    {
        //TRY CATCH: BOOL!!!
        public static void RegisterField(BE_Field field)
        {
            DAL_Field.RegisterField(field);
        }

        public static int GetFieldID(BE_Field field)
        {
            return DAL_Field.GetFieldID(field);
        }

        public static DataTable GetEstablishmentFields(int establishmentID)
        {
            return DAL_Field.GetEstablishmentFields(establishmentID);
        }
    }
}
