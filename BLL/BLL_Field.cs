using BE;
using DAL;
using System;
using System.Collections.Generic;
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
    }
}
