using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Data;

namespace BE
{
    public class BE_Establishment
    {
        private int id;
        private string name;
        private string email;
        private string phone;
        private string address;
        private BE_User owner;
        private List<BE_User> employees;
        private List<BE_Field> fields;

        public BE_Establishment(string name, string email, string phone, string address)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.address = address;
        }
        public BE_Establishment(DataRow r)
        {
            Id = r.Field<int>("idEstablishment");
            Name = r.Field<string>("establishmentName");
            Address = r.Field<string>("address");
            Phone = r.Field<string>("phone");
            Email = r.Field<string>("email");
            Employees = new List<BE_User>();
            Fields = new List<BE_Field>();
        }
        public BE_Establishment()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public List<BE_User> Employees { get => employees; set => employees = value; }
        public List<BE_Field> Fields { get => fields; set => fields = value; }
    }
}
