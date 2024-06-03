using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Employee
    {
        private int _id;
        private string _name;
        private string _surname;
        private string _email;
        private string _username;
        private string _password;
        private int _phone;

        public BE_Employee()
        {
            
        }

        public BE_Employee(int id, string name, string surname, string email, string username, string password,int phone)
        {
            this._id = id;
            this._name = name;
            this._surname = surname;
            this._email = email;
            this._username = username;
            this._password = password;
            this._phone = phone;
        }


        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Email { get => _email; set => _email = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public int Phone { get => _phone; set => _phone = value; }
    }
}
