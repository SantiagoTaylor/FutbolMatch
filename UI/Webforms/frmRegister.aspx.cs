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
        //Validad Campos
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxPassword.Visible = true;
            LabelPassword.Visible = true;
            if (!Page.IsPostBack)//
            {
                if (Request.QueryString["idEmploye"] != null)
                {
                    BE_Employee emp = BLL_Employee.GetEmployee(Request.QueryString["idEmploye"].ToString());
                    TextBoxName.Text = emp.Name;
                    TextBoxSurname.Text = emp.Surname;
                    TextBoxUsername.Text = emp.Username;
                    TextBoxPhone.Text = emp.Phone.ToString();
                    TextBoxPassword.Visible = false;
                    LabelPassword.Visible = false;
                    TextBoxEmail.Text = emp.Email;
                    ButtonRegister.Text = "Modificar";
                }
            }
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

            if (Request.QueryString["idEmploye"] != null)
            {
                BLL_Employee.UpdateEmployee(Request.QueryString["idEmploye"].ToString(), emp);
                Response.Redirect("frmEmployees.aspx");
            }
            else
            {
                if (BLL_Employee.SaveEmployee(emp))
                {

                }
                else {

                }
            }
        }
    }
}