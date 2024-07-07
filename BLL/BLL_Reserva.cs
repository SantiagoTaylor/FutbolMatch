using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Reserva
    {
        private DAL_Reserva reservaDAL = new DAL_Reserva();

        public void CrearReserva(BE.BE_Reserva reserva)
        {
            reservaDAL.CrearReserva(reserva);
        }

        public List<BE.BE_Reserva> ObtenerReservas()
        {
            return reservaDAL.ObtenerReservas();
        }
    }
}
