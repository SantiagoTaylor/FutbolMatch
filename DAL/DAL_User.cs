using BE;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DAL
{
    public class DAL_User
    {
        public static BE_User GetUserByUsername(string username)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = "sp_GetUserByUsername";
            command.Parameters.AddWithValue("@p_username", username);
            command.CommandType = CommandType.StoredProcedure;
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                BE_User user = new BE_User
                {
                    Username = reader["username"].ToString(),
                    Password = reader["password"].ToString(),
                    Name = reader["name"].ToString(),
                    Lastname = reader["lastname"].ToString(),
                    Email = reader["email"].ToString(),
                    Phone = reader["phone"] != DBNull.Value ? Convert.ToInt32(reader["phone"]) : 0,
                    Role = reader["roleName"].ToString(),
                    Language = reader["languageName"].ToString()
                };
                command.Connection = connection.CloseConnection();
                return user;
            }
            else
            {
                command.Connection = connection.CloseConnection();
                return null;
            }
        }

        #region Métodos ABML

        public static bool DeleteUser(string username)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = "DELETE FROM tb_User WHERE username = @username";
            command.CommandType= CommandType.Text;
            command.Parameters.AddWithValue("@username", username);
            int rowsAffected = command.ExecuteNonQuery();
            command.Connection = connection.CloseConnection();
            return rowsAffected > 0;
        }


        public static DataTable GetUsers()
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("sp_GetUsers", connection.Connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(table);
            return table;
        }

        public static bool SaveUser(BE_User user)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = "sp_InsertUser";
            command.Parameters.AddWithValue("@p_username", user.Username);
            command.Parameters.AddWithValue("@p_password", user.Password);
            command.Parameters.AddWithValue("@p_name", user.Name);
            command.Parameters.AddWithValue("@p_lastname", user.Lastname);
            command.Parameters.AddWithValue("@p_email", user.Email);
            command.Parameters.AddWithValue("@p_phone", user.Phone);
            command.Parameters.AddWithValue("@p_roleName", user.Role);
            command.Parameters.AddWithValue("@p_languageName", user.Language);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            command.Connection = connection.CloseConnection();
            //AGREGAR TRY CATCH
            return true;
        }

        public static bool UpdateUser(BE_User user)
        {

            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = "sp_UpdateUser";
            command.Parameters.AddWithValue("@p_username", user.Username);
            command.Parameters.AddWithValue("@p_name", user.Name);
            command.Parameters.AddWithValue("@p_lastname", user.Lastname);
            command.Parameters.AddWithValue("@p_email", user.Email);
            command.Parameters.AddWithValue("@p_phone", user.Phone);
            command.Parameters.AddWithValue("@p_roleName", user.Role);
            command.Parameters.AddWithValue("@p_languageName", user.Language);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            command.Connection = connection.CloseConnection();
            //AGREGAR TRY CATCH
            return true;
        }
        #endregion
    }
}
