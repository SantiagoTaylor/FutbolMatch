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

        public static void RecalculateDigits((string, string) tablePairs)
        {
            //ITEM 1: ORIGINAL
            //ITEM 2: DVH
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