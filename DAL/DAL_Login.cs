using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DAL_Login
    {
        public static bool UserExist(string username, string password)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = "sp_UserExist";
            command.Parameters.AddWithValue("@p_username", username);
            command.Parameters.AddWithValue("@p_password", password);
            command.CommandType = CommandType.StoredProcedure;
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Connection = connection.CloseConnection();
            return result >= 1;
        }
    }
}
