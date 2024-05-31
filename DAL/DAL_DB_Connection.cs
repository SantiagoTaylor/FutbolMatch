using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public  class DAL_DB_Connection
    {
        private  readonly SqlConnection _connection = new SqlConnection(@"Server=DESKTOP-RT3PVPT\SQLEXPRESS;Database=db_PruebaLogin;Trusted_Connection=True;");

        public SqlConnection Connection => _connection;
        public SqlConnection OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            return Connection;
        }

        public SqlConnection CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
            return Connection;
        }
    }
}
