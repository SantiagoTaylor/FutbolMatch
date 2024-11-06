using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE
{
    [Serializable]
    public class BE_User
    {
        private string _name;
        private string _lastname;
        private string _email;
        private string _username;
        private string _password;
        private string _phone;
        private string _role;
        private int _language;
        private bool _blocked;
        private bool _removed;

        public BE_User()
        {

        }

        public BE_User(DataRow r)
        {
            this._username = r.Field<string>("Usuario");
            this._name = r.Field<string>("Nombre");
            this._lastname = r.Field<string>("Apellido");
            this._email = r.Field<string>("Mail");
            this._phone = r.Field<string>("Telefono");
            this._role = r.Field<string>("Rol");
            this._language = r["Idioma"] != DBNull.Value && int.TryParse(r["Idioma"].ToString(), out int lang) ? lang : 0;
            this._blocked = Convert.ToBoolean(r["Bloqueado"]);
            this._removed= Convert.ToBoolean(r["Borrado"]);
        }

        public BE_User(string username, string password, string name, string lastname, string email, string phone, string role, int language)
        {
            this._username = username;
            this._password = password;
            this._name = name;
            this._lastname = lastname;
            this._email = email;
            this._phone = phone;
            this._role = role;
            this._language = language;
        }

        public BE_User(string username, string password, string name, string lastname, string email, string phone, string role, int language, bool blocked, bool removed)
        {
            this._username = username;
            this._password = password;
            this._name = name;
            this._lastname = lastname;
            this._email = email;
            this._phone = phone;
            this._role = role;
            this._language = language;
            this._blocked = blocked;
            this._removed = removed;
        }

        public string Name { get => _name; set => _name = value; }
        public string Lastname { get => _lastname; set => _lastname = value; }
        public string Email { get => _email; set => _email = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Role { get => _role; set => _role = value; }
        public int Language { get => _language; set => _language = value; }
        public bool Blocked { get => _blocked; set => _blocked = value; }
        public bool Removed { get => _removed; set => _removed = value; }
    }
}
