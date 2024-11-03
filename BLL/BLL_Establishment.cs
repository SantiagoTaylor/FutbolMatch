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
        public static bool DeleteEstablishment(string id)
        {
            return DAL_Establishment.DeleteEstablishmentById(id);
        }
        public static BE_Establishment GetEstablishment(string id)
        {
            return DAL_Establishment.GetEstablishmentById(id);
        }

        public static string GetEstablishmentName(string username)
        {
            return DAL_Establishment.GetEstablishmentName(username);
        }
        
        public static DataTable GetEstablishments()
        {
            return DAL_Establishment.GetAllEstablishments();
        }
        
        public static DataTable GetEstablishmentUsers(int idEstablishment)
        {
            return DAL_Establishment.GetEstablishmentUsers(idEstablishment);
        }
        
        public static DataTable GetUserEstablishments(BE_User user)
        {
            return DAL_Establishment.GetEstablishmentsByUsername(user);
        }
        /// <summary>
        /// Retorna una lista de los establecimientos que cuenta el ADMIN mas empleados y canchas
        /// </summary>
        /// <param name="user">username del Admin logeado</param>
        /// <returns>Lista de establecimientos mas empleados y canchas</returns>
        public static List<BE_Establishment> GetEstablishmentDetailsByUsername(BE_User user)
        {
            var est = DAL_Establishment.GetEstablishmentDetailsByUsername(user)
                     .AsEnumerable()
                     .Select(r => new BE_Establishment(r))
                     .ToList();
            est.ForEach(e =>
            {
                e.Employees = DAL_Establishment.GetEstablishmentUsers(e.Id)
                    .AsEnumerable()
                    .Select(emp => new BE_User(emp))
                    .ToList();

                e.Fields = DAL_Field.GetEstablishmentFields(e.Id)
                    .AsEnumerable()
                    .Select(field => new BE_Field(field))
                    .ToList();
            });
            return est;
        }

        public static bool RegisterEstablishment(BE_Establishment s)
        {
            return DAL_Establishment.RegisterEstablishment(s);
        }

        public static bool SetUserEstablishment(string user, string establishmentName)
        {
            return DAL_Establishment.SetUserEstablishment(user, establishmentName);
        }

        public static bool UpdateEstablishment(BE_Establishment s)
        {
            return DAL_Establishment.UpdateEstablishment(s);
        }
    }
}
