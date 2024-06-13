using MySqlConnector;
using System;
using System.Data;

namespace DAL
{
    public static class DAL_DatabaseIntegrity
    {
        public static DataTable GetHashedTable(string tableToHash)
        {
            DataTable hashedTable = new DataTable();
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = $"sp_GetHashedTable";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("p_table", tableToHash);
            MySqlDataReader reader = command.ExecuteReader();
            hashedTable.Load(reader);
            command.Connection = connection.CloseConnection();
            return hashedTable;
        }

        public static DataTable GetDVHTable(string table)
        {
            DataTable DVHTable = new DataTable();
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = $"SELECT * FROM {table}";
            command.CommandType = CommandType.Text;
            MySqlDataReader reader = command.ExecuteReader();
            DVHTable.Load(reader);
            command.Connection = connection.CloseConnection();
            return DVHTable;
        }

        //LO MISMO... QUIZAS UNA CLASE "UserDV"...
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
            command.Parameters.AddWithValue("@username2", row["username"]);
            command.CommandType = CommandType.Text;
            int affectedRows = command.ExecuteNonQuery();
            command.Connection = connection.CloseConnection();
            //AGREGAR TRY CATCH
        }

        public static void RecalculateDigits((string, string) tablePairs)
        {
            //ORIGINAL, DVH
            try
            {
                DAL_DB_Connection connection = new DAL_DB_Connection();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection.OpenConnection();
                command.CommandText = $"DELETE FROM {tablePairs.Item2}";
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                BulkCopy(tablePairs);
                command.Connection = connection.CloseConnection();
            }
            catch (Exception)
            {
            }
        }

        private static void BulkCopy((string, string) tablePairs)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlBulkCopy bulk = new MySqlBulkCopy(connection.OpenConnection());
            bulk.DestinationTableName = tablePairs.Item2;
            DataTable hashTable = GetHashedTable(tablePairs.Item1);
            bulk.WriteToServer(hashTable);
        }
    }
}