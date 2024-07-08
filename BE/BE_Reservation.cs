using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Reservation
    {
        private int _reservationID;
        private int _fieldID;
        private int _reservationTimeID;
        private string _username;
        private DateTime _date;

        public BE_Reservation(int fieldID, int reservationTimeID, string username, DateTime date)
        {
            _fieldID = fieldID;
            _reservationTimeID = reservationTimeID;
            _username = username;
            _date = date;
        }

        public int ReservationID { get => _reservationID; }
        public int FieldID { get => _fieldID; }
        public int ReservationTimeID { get => _reservationTimeID; }
        public string Username { get => _username; }
        public DateTime Date { get => _date; }
    }
}
