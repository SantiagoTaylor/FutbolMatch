using BE;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAL_Field
    {
        public static DataTable GetEstablishmentFields(int establishmentID)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("sp_GetEstablishmentFields", connection.Connection);
            adapter.SelectCommand.Parameters.AddWithValue("p_establishmentID", establishmentID);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(table);
            return table;
        }

        public static int GetFieldID(BE_Field field)
        {
            try
            {
                int result = 0;
                DAL_DB_Connection connection = new DAL_DB_Connection();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection.OpenConnection();
                command.CommandText = "SELECT idField FROM tb_Field WHERE idEstablishment = @idEstablishment AND fieldName = @fieldName AND size = @size AND floorType = @floorType";
                command.Parameters.AddWithValue("@idEstablishment", field.EstablishmentID);
                command.Parameters.AddWithValue("@fieldName", field.FieldName);
                command.Parameters.AddWithValue("@size", field.Size);
                command.Parameters.AddWithValue("@floorType", field.FloorType);
                command.CommandType = CommandType.Text;
                result = Convert.ToInt32(command.ExecuteScalar());
                command.Connection = connection.CloseConnection();
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static void RegisterField(BE_Field field)
        {
            try
            {
                DAL_DB_Connection connection = new DAL_DB_Connection();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection.OpenConnection();
                command.CommandText = @"sp_RegisterField";
                command.Parameters.AddWithValue("@p_idEstablishment", field.EstablishmentID);
                command.Parameters.AddWithValue("@p_fieldName", field.FieldName);
                command.Parameters.AddWithValue("@p_size", field.Size);
                command.Parameters.AddWithValue("@p_floorType", field.FloorType);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.Connection = connection.CloseConnection();
            }
            catch (Exception)
            {
            }
        }
    }
}
