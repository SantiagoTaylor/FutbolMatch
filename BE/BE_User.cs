using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_User
    {
        private string _name;
        private string _lastname;
        private string _email;
        private string _username;
        private string _password;
        private string _phone;
        private string _role;
        private string _language;
        private bool _blocked;
        private bool _removed;

        public BE_User()
        {

        }

        public BE_User(string username, string password, string name, string lastname, string email, string phone, string role, string language)
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

        public BE_User(string username, string password, string name, string lastname, string email, string phone, string role, string language, bool blocked, bool removed)
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
        public string Language { get => _language; set => _language = value; }
        public bool Blocked { get => _blocked; set => _blocked = value; }
        public bool Removed { get => _removed; set => _removed = value; }
    }
}
