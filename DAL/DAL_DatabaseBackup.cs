using MySql.Data.MySqlClient;
using System;

namespace DAL
{
    public static class DAL_DatabaseBackup
    {
        public static void Backup(string backupFilePath)
        {
            string connectionString = Environment.GetEnvironmentVariable("MY_CONNECTION_STRING");
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        mb.ExportToFile(backupFilePath);
                    }
                }
            }
        }

        public static void Restore(string backupFilePath)
        {
            string connectionString = Environment.GetEnvironmentVariable("MY_CONNECTION_STRING");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(backupFilePath);
                        conn.Close();
                    }
                }
            }
        }
    }
}
