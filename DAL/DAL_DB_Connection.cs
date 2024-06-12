using MySql.Data.MySqlClient;
<<<<<<< HEAD
using System.Data;
=======
using System;
>>>>>>> abel

namespace DAL
{
    public class DAL_DB_Connection
    {
<<<<<<< HEAD
        private readonly MySqlConnection _connection = new MySqlConnection(@"Server=fm-db.c9s4ay4c0uqw.us-east-2.rds.amazonaws.com;Database=db_FutbolMatch;User ID=admin;Password=wasQWU7Y4l;Port=3306;SslMode=none;");
=======
        private static string connectionString = Environment.GetEnvironmentVariable("MY_CONNECTION_STRING");

        private readonly MySqlConnection _connection = new MySqlConnection(connectionString);
>>>>>>> abel

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
