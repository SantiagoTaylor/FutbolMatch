using MySql.Data.MySqlClient;
using System.Data;

namespace DAL
{
    public static class DAL_Role
    {
        public static DataTable GetRoles()
        {
            DAL_DB_Connection connection = new DAL_DB_Connection();
            DataTable table = new DataTable();
            //CREAR SP!!
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tb_Role", connection.Connection);
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(table);
            return table;
        }
    }
}
