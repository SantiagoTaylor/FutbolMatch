using BE;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAL_Reservation
    {
        public static DataTable GetReservations(string establishmenName)
        {
            Console.WriteLine(establishmenName);
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("sp_GetReserves", connection.Connection);
            adapter.SelectCommand.Parameters.AddWithValue("@p_estName", establishmenName);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(table);
            return table;
        }

        public static DataTable GetUserReservations(string username)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("sp_GetUserReservations", connection.Connection);
            adapter.SelectCommand.Parameters.AddWithValue("p_username", username);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(table);
            return table;
        }

        public static bool RegisterReservation(BE_Reservation reservation)
        {
            try
            {
                DAL_DB_Connection connection = new DAL_DB_Connection();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection.OpenConnection();
                command.CommandText = @"sp_RegisterReservation";
                command.Parameters.AddWithValue("@p_idField", reservation.FieldID);
                command.Parameters.AddWithValue("@p_idReservationTime", reservation.ReservationTimeID);
                command.Parameters.AddWithValue("@p_username", reservation.Username);
                command.Parameters.AddWithValue("@p_date", reservation.Date);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.Connection = connection.CloseConnection();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
