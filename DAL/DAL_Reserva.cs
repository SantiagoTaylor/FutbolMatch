using BE;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Reserva
    {
        private string connectionString = Environment.GetEnvironmentVariable("MY_CONNECTION_STRING");

        public void CrearReserva(BE_Reserva reserva)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO tb_Reservas (CanchaID, UsuarioID, HorarioID, Fecha) VALUES (@CanchaID, @UsuarioID, @HorarioID, @Fecha)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CanchaID", reserva.CanchaID);
                    cmd.Parameters.AddWithValue("@UsuarioID", reserva.UsuarioID);
                    cmd.Parameters.AddWithValue("@HorarioID", reserva.HorarioID);
                    cmd.Parameters.AddWithValue("@Fecha", reserva.Fecha);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<BE_Reserva> ObtenerReservas()
        {
            List<BE_Reserva> reservas = new List<BE_Reserva>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ReservaID, CanchaID, UsuarioID, HorarioID, Fecha FROM tb_Reservas";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reservas.Add(new BE_Reserva
                            {
                                ReservaID = reader.GetInt32("ReservaID"),
                                CanchaID = reader.GetInt32("CanchaID"),
                                UsuarioID = reader.GetString("UsuarioID"),
                                HorarioID = reader.GetInt32("HorarioID"),
                                Fecha = reader.GetDateTime("Fecha")
                            });
                        }
                    }
                }
            }

            return reservas;
        }
    }
}
