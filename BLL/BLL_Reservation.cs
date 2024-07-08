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

        public static void RegisterReservation(BE_Reservation reservation)
        {
            DAL_Reservation.RegisterReservation(reservation);
        }
    }
}
