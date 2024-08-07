﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BE
{
    public class BE_Establishment
    {
        private int id;
        private string name;
        private string email;
        private string phone;
        private string adress;
        private BE_User owner;
        private List<BE_User> employees;
        private List<BE_Field> fields;

        public BE_Establishment(string name, string email, string phone, string adress)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.adress = adress;
        }
        public BE_Establishment()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Adress { get => adress; set => adress = value; }
        public List<BE_Field> Fields { get => fields; set => fields = value; }
    }
}
