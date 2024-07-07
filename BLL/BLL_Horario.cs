using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Horario
    {
        private DAL_Horario horarioDAL = new DAL_Horario();

        public List<BE_Horario> ObtenerHorarios(int canchaID)
        {
            return horarioDAL.ObtenerHorarios(canchaID);
        }

        public void CrearHorario(BE_Horario horario)
        {
            horarioDAL.CrearHorario(horario);
        }
    }
}
