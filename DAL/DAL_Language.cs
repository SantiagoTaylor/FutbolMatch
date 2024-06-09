using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DAL_Language
    {
        public static DataTable GetLanguages()
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            //CREAR SP!!
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT idLanguage, languageName FROM tb_Language", connection.Connection);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(table);
            return table;
        }
    }
}
