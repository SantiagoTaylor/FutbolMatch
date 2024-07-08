using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAL_ReservationTimes
    {
        public static DataTable GetAvailableTimesByDate(int fieldID, string date)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("sp_GetAvailableTimesByDate", connection.Connection);
            adapter.SelectCommand.Parameters.AddWithValue("p_idField", fieldID);
            adapter.SelectCommand.Parameters.AddWithValue("p_date", date);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(table);
            return table;
        }

        public static DataTable GetReservationTimes()
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tb_ReservationTimes", connection.Connection);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(table);
            return table;
        }

        public static void RegisterFieldReservationTimes(int startHourID, int endHourID, int fieldID)
        {
            try
            {
                DAL_DB_Connection connection = new DAL_DB_Connection();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection.OpenConnection();
                for (int i = startHourID; i < endHourID; i++)
                {
                    command.CommandText = @"sp_RegisterFieldReservationTimes";
                    command.Parameters.AddWithValue("@p_fieldID", fieldID);
                    command.Parameters.AddWithValue("@p_hourID", i);
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                command.Connection = connection.CloseConnection();
            }
            catch (Exception)
            {
            }
        }
    }
}
