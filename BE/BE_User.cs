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
        private int _phone;
        private string _role;

        public BE_User()
        {

        }

        public BE_User(string username, string password, string name, string lastname, string email, int phone, string role)
        {
            this._username = username;
            this._password = password;
            this._name = name;
            this._lastname = lastname;
            this._email = email;
            this._phone = phone;
            this._role = role;
        }

        public string Name { get => _name; set => _name = value; }
        public string Lastname { get => _lastname; set => _lastname = value; }
        public string Email { get => _email; set => _email = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public int Phone { get => _phone; set => _phone = value; }
        public string Role { get => _role; set => _role = value; }
    }
}
