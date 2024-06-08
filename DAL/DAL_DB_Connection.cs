    
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DAL_DB_Connection
    {
        private readonly MySqlConnection _connection = new MySqlConnection(@"Server=fm-db.c9s4ay4c0uqw.us-east-2.rds.amazonaws.com;Database=db_FutbolMatch;User ID=admin;Password=wasQWU7Y4l");

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
