using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Web.Security;

namespace SERVICES
{
    internal class RoleManager : RoleProvider
    {
        private string connectionString;

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (string.IsNullOrEmpty(name))
                name = "MySqlRoleProvider";

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "My SQL Role Provider");
            }

            base.Initialize(name, config);

            // Obtén la cadena de conexión de la variable de entorno
            string envVarName = config["connectionStringEnvironmentVariable"];
            connectionString = Environment.GetEnvironmentVariable(envVarName);

            if (string.IsNullOrEmpty(connectionString))
                throw new ProviderException("Connection string cannot be blank.");
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM tb_User u INNER JOIN tb_Role r ON u.role = r.idRole WHERE u.username = @username AND r.roleName = @roleName", conn);
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@roleName", MySqlDbType.VarChar).Value = roleName;

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT r.roleName FROM tb_User u INNER JOIN tb_Role r ON u.role = r.idRole WHERE u.username = @username", conn);
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string> roles = new List<string>();
                    while (reader.Read())
                    {
                        roles.Add(reader["roleName"].ToString());
                    }
                    return roles.ToArray();
                }
            }
        }

        // MÉTODOS HEREDADOS NO UTILIZADOS:
        public override void AddUsersToRoles(string[] usernames, string[] roleNames) { throw new NotImplementedException(); }
        public override void CreateRole(string roleName) { throw new NotImplementedException(); }
        public override string ApplicationName { get; set; }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole) { throw new NotImplementedException(); }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch) { throw new NotImplementedException(); }
        public override string[] GetAllRoles() { throw new NotImplementedException(); }
        public override string[] GetUsersInRole(string roleName) { throw new NotImplementedException(); }
        public override bool RoleExists(string roleName) { throw new NotImplementedException(); }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames) { throw new NotImplementedException(); }
    }
}
