using BLL;
using System;
using SERVICES;

namespace UI.Webforms
{
    public partial class frmLogin : System.Web.UI.Page
    {
        private static int _failedLogins = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (BLL_Login.IsValidCredentials(txtUser.Text, txtPassword.Text))
            {
                WebformMessage.ShowMessage("Bienvenido!", this);
                _failedLogins = 0;
                Response.Redirect("index.aspx");
            }
            else
            {
                WebformMessage.ShowMessage("El usuario o la contraseña son incorrectos" + _failedLogins, this);
                _failedLogins++;
            }
        }
    }
}