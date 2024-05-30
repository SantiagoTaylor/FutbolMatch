using BLL;
using System;
using SERVICES;

namespace UI.Webforms
{
    public partial class frmLogin : System.Web.UI.Page
    {
        private int _failedLogins = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (BLL_Login.IsValidCredentials(txtUser.Text, txtPassword.Text))
            {
                WebformMessage.ShowMessage("Bienvenido!", this);
            }
            else
            {
                WebformMessage.ShowMessage("El usuario o la contraseña son incorrectos", this);
                _failedLogins++;
            }
        }
    }
}