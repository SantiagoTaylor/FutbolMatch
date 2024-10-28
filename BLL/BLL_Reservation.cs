using BE;
using DAL;
using SERVICES;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.ModelBinding;

namespace BLL
{
    public static class BLL_Reservation
    {
        public static DataTable GetUserReservations(BE_User user)
        {
            return DAL_Reservation.GetUserReservations(user.Username);
        }

        public static DataTable GetReservations(string establishmentName)
        {
            IEnumerable<DataRow> dt = from row in DAL_Reservation.GetReservations(establishmentName).AsEnumerable()
                                      orderby row.Field<DateTime>("date"), row.Field<TimeSpan>("startHour")
                                      select row;

            if (SessionManager.GetInstance.User.Role == "USER")
            {
                dt = from row in dt where row.Field<DateTime>("date") > DateTime.Today select row;
            }

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
