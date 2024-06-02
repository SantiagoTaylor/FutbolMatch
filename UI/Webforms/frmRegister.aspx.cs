using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;
using SERVICES;

namespace UI.Webforms
{
    public partial class frmRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            BE_Employee emp = new BE_Employee(0,
                TextBoxName.Text,
                TextBoxSurname.Text,
                TextBoxEmail.Text,
                TextBoxUsername.Text,
                Encrpyt.HashPassword(TextBoxPassword.Text),
                int.Parse(TextBoxPhone.Text));


            if (BLL_Employee.SaveEmployee(emp))
            {
                
            }
            else { }
        }
    }
}