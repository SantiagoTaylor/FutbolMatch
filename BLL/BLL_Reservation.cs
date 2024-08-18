using BE;
using DAL;
using System;
using System.Data;
using System.Linq;

namespace BLL
{
    public static class BLL_Reservation
    {
        public static DataTable GetUserReservations(BE_User user)
        {
            return DAL_Reservation.GetUserReservations(user.Username);
        }

        public static DataTable GetReservations(string establishmenName)
        {
            var dt = from row in DAL_Reservation.GetReservations(establishmenName).AsEnumerable()
                     orderby row.Field<DateTime>("date"), row.Field<TimeSpan>("startHour")
                     select row;
            if (!dt.Any())
            {
                return null;
            }
            return dt.CopyToDataTable();
        }

        public static bool RegisterReservation(BE_Reservation reservation)
        {
            return DAL_Reservation.RegisterReservation(reservation);
        }
    }
}
