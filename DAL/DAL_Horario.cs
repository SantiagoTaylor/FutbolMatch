using BE;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Horario
    {
        private string connectionString = Environment.GetEnvironmentVariable("MY_CONNECTION_STRING");

        public List<BE_Horario> ObtenerHorarios(int canchaID)
        {
            List<BE_Horario> horarios = new List<BE_Horario>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT HorarioID, CanchaID, HoraInicio, HoraFin FROM tb_Horarios WHERE CanchaID = @CanchaID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CanchaID", canchaID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            horarios.Add(new BE_Horario
                            {
                                HorarioID = reader.GetInt32("HorarioID"),
                                CanchaID = reader.GetInt32("CanchaID"),
                                HoraInicio = reader.GetTimeSpan("HoraInicio"),
                                HoraFin = reader.GetTimeSpan("HoraFin")
                            });
                        }
                    }
                }
            }

            return horarios;
        }

        public void CrearHorario(BE_Horario horario)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO tb_Horarios (CanchaID, HoraInicio, HoraFin) VALUES (@CanchaID, @HoraInicio, @HoraFin)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CanchaID", horario.CanchaID);
                    cmd.Parameters.AddWithValue("@HoraInicio", horario.HoraInicio);
                    cmd.Parameters.AddWithValue("@HoraFin", horario.HoraFin);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
