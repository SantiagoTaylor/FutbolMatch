using BE;
using DAL;
using System;
using System.Data;

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
            return DAL_Reservation.GetReservations(establishmenName);
        }

        public static bool RegisterReservation(BE_Reservation reservation)
        {
            return DAL_Reservation.RegisterReservation(reservation);
        }
    }
}
