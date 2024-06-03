using BE;
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_Employee
    {
        public static bool DeleteEmployee(string id)
        {
            DAL_DB_Connection dbC = new DAL_DB_Connection();
            MySqlConnection conn = dbC.Connection;
            string query = "DELETE FROM Employe WHERE idEmploye = @Id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected > 0;
        }

        public static BE_Employee GetEmployee(string id)
        {
            DAL_DB_Connection dbC = new DAL_DB_Connection();
            MySqlConnection conn = dbC.Connection;
            string query = "SELECT * FROM Employe WHERE idEmploye = @Id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) { 
                BE_Employee emp = new BE_Employee();
                emp.Id=Convert.ToInt32(reader["idEmploye"]);
                emp.Name=reader["name"].ToString();
                emp.Surname = reader["surname"].ToString();
                emp.Email=reader["email"].ToString();
                emp.Username=reader["username"].ToString();
                emp.Password = reader["password"].ToString();
                emp.Phone = reader["phone"] != DBNull.Value ? Convert.ToInt32(reader["phone"]) : 0;
                conn.Close();
                return emp;
            }
            else
            {
                conn.Close();
                return null;
            }
            
        }

        public static DataTable GetEmployees()
        {
            DAL_DB_Connection dbC = new DAL_DB_Connection();
            DataTable _dt = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter("SELECT * FROM Employe",dbC.Connection);
            DA.SelectCommand.CommandType = CommandType.Text;
            DA.Fill(_dt);
            _dt.Columns.Remove("password");
            return _dt;
        }
        public static bool SaveEmployee(BE_Employee emp)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlConnection conn = null;
            MySqlCommand command = new MySqlCommand();

            try
            {
                conn = connection.OpenConnection();
                command.Connection = conn;
                command.CommandText = "INSERT INTO Employe (name, surname, email, username, password, phone) VALUES (@Name, @Surname, @Email, @Username, @Password, @Phone)";
                command.Parameters.AddWithValue("@Name", emp.Name);
                command.Parameters.AddWithValue("@Surname", emp.Surname);
                command.Parameters.AddWithValue("@Email", emp.Email);
                command.Parameters.AddWithValue("@Username", emp.Username);
                command.Parameters.AddWithValue("@Password", emp.Password);
                command.Parameters.AddWithValue("@Phone", emp.Phone);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

        public static bool UpdateEmployee(string id, BE_Employee emp)
        {
            
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlConnection conn = null;
            MySqlCommand command = new MySqlCommand();

            try
            {
                conn = connection.OpenConnection();
                command.Connection = conn;
                command.CommandText = "UPDATE Employe SET name = @Name, surname = @Surname, email = @Email, username = @Username, phone = @Phone WHERE idEmploye = @Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", emp.Name);
                command.Parameters.AddWithValue("@Surname", emp.Surname);
                command.Parameters.AddWithValue("@Email", emp.Email);
                command.Parameters.AddWithValue("@Username", emp.Username);
                command.Parameters.AddWithValue("@Phone", emp.Phone);
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

    }
}
