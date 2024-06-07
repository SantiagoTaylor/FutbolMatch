using BE;
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

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
            DAL_DB_Connection dbC = new DAL_DB_Connection();
            MySqlConnection conn = dbC.Connection;
            string query = "DELETE FROM tb_User WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
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
            MySqlConnection conn = null;
            MySqlCommand command = new MySqlCommand();

            try
            {
                conn = connection.OpenConnection();
                command.Connection = conn;
                command.CommandText = "sp_InsertUser";
                command.Parameters.AddWithValue("@p_username", user.Username);
                command.Parameters.AddWithValue("@p_password", user.Password);
                command.Parameters.AddWithValue("@p_name", user.Name);
                command.Parameters.AddWithValue("@p_lastname", user.Lastname);
                command.Parameters.AddWithValue("@p_email", user.Email);
                command.Parameters.AddWithValue("@p_phone", user.Phone);
                command.Parameters.AddWithValue("@p_roleName", user.Role);
                //ROL STRING -> ROL ID en el SP
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

        public static bool UpdateUser(BE_User user)
        {

            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlConnection conn = null;
            MySqlCommand command = new MySqlCommand();

            try
            {
                conn = connection.OpenConnection();
                command.Connection = conn;
                command.CommandText = "sp_UpdateUser";
                command.Parameters.AddWithValue("@p_username", user.Username);
                command.Parameters.AddWithValue("@p_name", user.Name);
                command.Parameters.AddWithValue("@p_lastname", user.Lastname);
                command.Parameters.AddWithValue("@p_email", user.Email);
                command.Parameters.AddWithValue("@p_phone", user.Phone);
                command.Parameters.AddWithValue("@p_roleName", user.Role);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
        #endregion
    }
}
