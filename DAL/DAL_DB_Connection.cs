using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_DB_Connection
    {
        private readonly MySqlConnection _connection = new MySqlConnection(@"Server=sql10.freesqldatabase.com;Database=sql10710948;User ID=sql10710948;Password=wasQWU7Y4l");

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