using BE;
using MySqlConnector;
using System;
using System.Data;
using System.Diagnostics;

namespace DAL
{
    public static class DAL_EventLog
    {
        public static void RegisterEventLog(BE_EventLog eventLog)
        {
            try
            {
                DAL_DB_Connection connection = new DAL_DB_Connection();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection.OpenConnection();
                command.CommandText = @"sp_InsertEventLog";
                command.Parameters.AddWithValue("@p_username", eventLog.Username);
                command.Parameters.AddWithValue("@p_activity", eventLog.Activity);
                command.Parameters.AddWithValue("@p_eventDate", eventLog.EventDate);
                command.Parameters.AddWithValue("@p_eventTime", eventLog.EventTime);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.Connection = connection.CloseConnection();
            }
            catch (Exception)
            {
            }
        }

        public static DataTable GetEventLog(string language = "English")
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("sp_GetEventLog", connection.Connection);
            adapter.SelectCommand.Parameters.AddWithValue("p_languageName", language);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(table);
            return table;
        }

        public static object GetActivityLevels(string language = "English")
        {
            DataTable table = new DataTable();
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = "sp_GetActivityLevels";
            command.Parameters.AddWithValue("@p_Language", language);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            MySqlDataReader _reader = command.ExecuteReader();
            table.Load(_reader);
            command.Connection = connection.CloseConnection();
            return table;
        }
    }
}
