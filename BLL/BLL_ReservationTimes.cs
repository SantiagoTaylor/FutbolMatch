using System;
using System.Data;
using DAL;

namespace BLL
{
    public static class BLL_ReservationTimes
    {
        public static DataTable GetAvailableTimesByDate(int fieldID, string date)
        {
            DataTable dtAvailableTimes = new DataTable();

            dtAvailableTimes.Columns.Add("idReservationTimes", typeof(int));
            dtAvailableTimes.Columns.Add("startHour", typeof(DateTime));
            dtAvailableTimes.Columns.Add("endHour", typeof(DateTime));

            
            DateTime providedDate;
            DateTime.TryParse(date, out providedDate);

            DateTime now = DateTime.Now;
            DateTime currentDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);

            // Trae horarios disponibles
            foreach (DataRow dr in DAL_ReservationTimes.GetAvailableTimesByDate(fieldID, date).Rows)
            {
                DateTime startDateTime;
                TimeSpan startTime, endTime;

                if (DateTime.TryParse($"{providedDate.ToShortDateString()} {dr["startHour"]}", out startDateTime))
                {
                    startTime = startDateTime.TimeOfDay;
                    if (startDateTime > currentDateTime)
                    {
                        DataRow newRow = dtAvailableTimes.NewRow();

                        newRow["idReservationTimes"] = dr["idReservationTimes"];
                        newRow["startHour"] = startTime.ToString(@"hh\:mm\:ss");
                        newRow["endHour"] = dr["endHour"].ToString();

                        dtAvailableTimes.Rows.Add(newRow);
                    }
                }
                else
                {
                    throw new FormatException("Formato de hora no válido.");
                }
            }

            return dtAvailableTimes;
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
