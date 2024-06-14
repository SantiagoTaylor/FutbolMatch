using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAL_DV_User
    {
        public static DataTable HashedRowUser(string username)
        {
            DataTable hashedTable = new DataTable();
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = $"sp_HashedRowUser";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("p_username", username);
            MySqlDataReader reader = command.ExecuteReader();
            hashedTable.Load(reader);
            command.Connection = connection.CloseConnection();
            return hashedTable;
        }

        public static void InsertDV(DataTable table)
        {
            if (table.Rows.Count == 0)
            {
                throw new ArgumentException("DataTable has no rows.");
            }
            DataRow row = table.Rows[0];
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = "INSERT INTO tb_DVH_User (username, HashValue) VALUES (@username, @HashValue)";
            command.Parameters.AddWithValue("@username", row["username"]);
            command.Parameters.AddWithValue("@HashValue", row["HashValue"]);
            command.CommandType = CommandType.Text;
            int affectedRows = command.ExecuteNonQuery();
            command.Connection = connection.CloseConnection();
            //AGREGAR TRY CATCH
        }

        public static void UpdateDV(DataTable table)
        {
            if (table.Rows.Count == 0)
            {
                throw new ArgumentException("DataTable has no rows.");
            }
            DataRow row = table.Rows[0];
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = "UPDATE tb_DVH_User SET username = @username, HashValue = @HashValue WHERE username = @username2";
            command.Parameters.AddWithValue("@username", row["username"]);
            command.Parameters.AddWithValue("@HashValue", row["HashValue"]);
            command.Parameters.AddWithValue("@username2", row["username"]);//nc si hace falta
            command.CommandType = CommandType.Text;
            int affectedRows = command.ExecuteNonQuery();
            command.Connection = connection.CloseConnection();
            //AGREGAR TRY CATCH
        }
    }
}
