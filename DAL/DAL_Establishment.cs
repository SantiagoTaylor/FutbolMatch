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
    public static class DAL_Establishment
    {
        public static DataTable GetEstablishments()
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tb_Estalishment", connection.Connection);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(table);
            return table;
        }

        public static DataTable GetUserEstablishments(BE_User user)
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(@"SELECT e.idEstablishment, e.establishmentName, eu.username FROM tb_EstablishmentUser eu JOIN tb_Establishment e ON e.idEstablishment = eu.idEstablishment WHERE eu.username = @username", connection.Connection);
            adapter.SelectCommand.Parameters.AddWithValue("username", user.Username);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(table);
            return table;
        }
    }
}