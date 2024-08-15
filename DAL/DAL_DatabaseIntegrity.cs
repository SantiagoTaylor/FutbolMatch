using MySqlConnector;
using MySqlX.XDevAPI.Relational;
using System;
using System.Data;
using System.Linq;

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

        public static void RecalculateTables((string, string) tablePairs)
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
                command.Connection = connection.CloseConnection();
                BulkCopy(tablePairs);
            }
            catch (Exception)
            {
            }
        }

        private static void BulkCopy((string, string) tablePairs)
        {
            //SI NO FUERA POR LA PÁGINA QUE NO DEJA UTILIZAR TABLAS EXTERNAS,
            //UTILIZARÍA BULKCOPY QUE ES MUCHISIMO MÁS RÁPIDO
            //PORQUE COPIA LA TABLA ENTERA EN VEZ DE FILAxFILA
            DataTable hashTable = GetHashedTable(tablePairs.Item1);
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            string columns = string.Join(", ", hashTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            string values = string.Join(", ", hashTable.Columns.Cast<DataColumn>().Select(c => "@" + c.ColumnName));
            command.CommandText = $"INSERT INTO {tablePairs.Item2} ({columns}) VALUES ({values})";
            foreach (DataRow row in hashTable.Rows)
            {
                command.Parameters.Clear();
                foreach (DataColumn column in hashTable.Columns)
                {
                    command.Parameters.AddWithValue("@" + column.ColumnName, row[column]);
                }
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            command.Connection = connection.CloseConnection();
        }
    }
}