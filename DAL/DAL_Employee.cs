using BE;
using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public class DAL_Employee
    {
        public static DataTable GetEmployees()
        {
            DAL_DB_Connection dbC = new DAL_DB_Connection();
            DataTable _dt = new DataTable();
            MySqlDataAdapter DA = new MySqlDataAdapter("SELECT * FROM Employe",dbC.Connection);
            DA.SelectCommand.CommandType = CommandType.Text;
            DA.Fill(_dt);
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

    }
}
