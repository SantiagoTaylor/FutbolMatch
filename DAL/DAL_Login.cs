using BE;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_Login
    {
        public static BE_Login GetUserByUsername(string user)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            BE_Login login = new BE_Login();
            command.Connection = connection.OpenConnection();
            command.CommandText = "SELECT * FROM tb_User AS u WHERE u.username = @user;";
            command.Parameters.AddWithValue("@user", user);
            command.CommandType = CommandType.Text;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                login.User = Convert.ToString(reader["username"]);
                //lo demas
            }
            command.Connection = connection.CloseConnection();
            return login;
        }

        public static DataTable GetUsers()
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            DataTable table = new DataTable();
            command.Connection = connection.OpenConnection();
            command.CommandText = "SELECT * FROM tb_User";
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            command.Connection = connection.CloseConnection();
            return table;
        }

        public static bool UserExist(string user, string password)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            BE_Login login = new BE_Login();
            command.Connection = connection.OpenConnection();
            command.CommandText = "sp_UserExist";
            command.Parameters.AddWithValue("@user1", user);
            command.Parameters.AddWithValue("@pass1", password);
            command.CommandType = CommandType.StoredProcedure;
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Connection = connection.CloseConnection();
            return result >= 1;
        }
    }
}
