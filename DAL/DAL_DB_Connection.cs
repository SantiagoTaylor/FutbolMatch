using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public class DAL_DB_Connection
    {
        private static string connectionString = Environment.GetEnvironmentVariable("MY_CONNECTION_STRING");
        //private static string connectionString = Environment.GetEnvironmentVariable("FILESS_CONNECTION_STRING");

        private readonly MySqlConnection _connection = new MySqlConnection(connectionString);

        public MySqlConnection Connection => _connection;
        public MySqlConnection OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            return Connection;
        }

        public MySqlConnection CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
            return Connection;
        }
    }
}
