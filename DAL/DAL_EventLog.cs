using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MySql.Data.MySqlClient;

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
                //FALTA SP!!!
                command.CommandText = @"FALTA SP!!";
                //command.Parameters.AddWithValue("@fecha", eventLog.Fecha);
                //command.Parameters.AddWithValue("@hora", eventLog.Hora);
                //command.Parameters.AddWithValue("@usuario", eventLog.Usuario.Usuario);
                //command.Parameters.AddWithValue("@modulo", eventLog.Modulo);
                //command.Parameters.AddWithValue("@actividad", eventLog.Actividad);
                //command.Parameters.AddWithValue("@criticidad", eventLog.Criticidad);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.Connection = connection.CloseConnection();
            }
            catch (Exception)
            {
            }
        }

        public static DataTable GetEventLog()
        {
            DataTable table = new DataTable();
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            //FALTA SP!!!
            //SESION MANAGER -> USUARIO -> IDIOMA
            //IDIOMA = PARAMETRO
            // 1 POR DEFAULT??
            command.CommandText = "FALTA SP!!!";
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            MySqlDataReader _reader = command.ExecuteReader();
            table.Load(_reader);
            command.Connection = connection.CloseConnection();
            return table;
        }

        public static DataTable GetActivityLevel()
        {
            DataTable table = new DataTable();
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            //FALTA SP!!!
            command.CommandText = "FALTA SP!!!";
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            MySqlDataReader _reader = command.ExecuteReader();
            table.Load(_reader);
            command.Connection = connection.CloseConnection();
            return table;
        }
    }
}
