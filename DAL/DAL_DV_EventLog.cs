using BE;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAL_DV_EventLog
    {
        public static DataTable HashedRowEventLog(int idEventlog)
        {
            DataTable hashedTable = new DataTable();
            DAL_DB_Connection connection = new DAL_DB_Connection();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection.OpenConnection();
            command.CommandText = "sp_HashedRowEventLog";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("p_idEventLog", idEventlog);
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
            command.CommandText = "INSERT INTO tb_DVH_EventLog (idEventLog, HashValue) VALUES (@idEventLog, @HashValue)";
            command.Parameters.AddWithValue("@idEventLog", row["idEventLog"]);
            command.Parameters.AddWithValue("@HashValue", row["HashValue"]);
            command.CommandType = CommandType.Text;
            int affectedRows = command.ExecuteNonQuery();
            command.Connection = connection.CloseConnection();
            //AGREGAR TRY CATCH
        }
    }
}
