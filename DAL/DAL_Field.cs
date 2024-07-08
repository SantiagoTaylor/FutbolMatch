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
