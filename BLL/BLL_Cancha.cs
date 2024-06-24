using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace BLL
{
    public class BLL_Cancha
    {
        private DAL_Cancha canchaDAL = new DAL_Cancha();

        public List<BE.BE_Cancha> ObtenerCanchas()
        {
            return canchaDAL.ObtenerCanchas();
        }

        public void CrearCancha(BE.BE_Cancha cancha)
        {
            canchaDAL.CrearCancha(cancha);
        }
    }
}
