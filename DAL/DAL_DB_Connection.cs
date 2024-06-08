using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public class DAL_DB_Connection
    {
        //ACTUALIZAR CONNECTION STRING !!!
        private readonly MySqlConnection _connection = new MySqlConnection(@"Server=fm-db.c9s4ay4c0uqw.us-east-2.rds.amazonaws.com;Database=db_FutbolMatch;User ID=admin;Password=wasQWU7Y4l;Port=3306;SslMode=none;");

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
