using DAL;
using System;
using System.Data;

namespace BLL
{
    public static class BLL_ReservationTimes
    {
        public static DataTable GetAvailableTimesByDate(int fieldID, string date)
        {
            DataTable availableTimes = DAL_ReservationTimes.GetAvailableTimesByDate(fieldID, date);

            string today = DateTime.Now.ToString("yyyy-MM-dd");
            if (date != today)
            {
                return availableTimes;
            }

            TimeSpan hourMinutes = DateTime.Now.TimeOfDay;
            var filteredTimes = availableTimes.AsEnumerable().
                Where(row => row.Field<TimeSpan>("startHour") >= hourMinutes);

            return filteredTimes.CopyToDataTable();
        }

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
