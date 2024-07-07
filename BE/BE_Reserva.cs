using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Reserva
    {
        public int ReservaID { get; set; }
        public int CanchaID { get; set; }
        public string UsuarioID { get; set; }
        public int HorarioID { get; set; }
        public DateTime Fecha { get; set; }
    }
}
