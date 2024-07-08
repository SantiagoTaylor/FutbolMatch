using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Establishment
    {
        private int id;
        private string name;
        private string email;
        private string phone;
        private string adress;
        private List<BE_Field> fields;

        public BE_Establishment(string name, string email, string phone, string adress)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Adress = adress;
        }

        public int Id { get => id; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Adress { get => adress; set => adress = value; }
        public List<BE_Field> Fields { get => fields; set => fields = value; }
    }
}
