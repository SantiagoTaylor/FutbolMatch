using BE;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Cancha
    {
        private string connectionString = Environment.GetEnvironmentVariable("MY_CONNECTION_STRING");

        public List<BE_Cancha> ObtenerCanchas()
        {
            List<BE_Cancha> canchas = new List<BE_Cancha>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT CanchaID, Nombre FROM tb_Canchas";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            canchas.Add(new BE_Cancha
                            {
                                CanchaID = reader.GetInt32("CanchaID"),
                                Nombre = reader.GetString("Nombre")
                            });
                        }
                    }
                }
            }

            return canchas;
        }

        public void CrearCancha(BE_Cancha cancha)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO tb_Canchas (Nombre) VALUES (@Nombre)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", cancha.Nombre);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

