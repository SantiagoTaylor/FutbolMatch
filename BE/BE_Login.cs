using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Login
    {
        private string _user;
        private string _password;

        public string User { get => _user; set => _user = value; }
        public string Password { get => _password; set => _password = value; }

        public BE_Login() { }

        public BE_Login(string user, string password)
        {
            _user = user;
            _password = password;
        }
    }
}
