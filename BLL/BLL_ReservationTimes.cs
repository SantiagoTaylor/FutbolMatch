using System;
using System.Data;
using DAL;

namespace BLL
{
    public static class BLL_ReservationTimes
    {
        public static DataTable GetReservationTimes()
        {
            return DAL_ReservationTimes.GetReservationTimes();
        }

        public static void RegisterFieldReservationTimes(int startHourID, int endHourID, int fieldID)
        {
            DAL_ReservationTimes.RegisterFieldReservationTimes(startHourID, endHourID, fieldID);
        }
    }
}
