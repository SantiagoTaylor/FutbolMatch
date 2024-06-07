using BLL;
using System;
using SERVICES;
using System.Web.Security;
using System.Web;

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
                //tiene que ser distinto y guardar un seguimiento de usuarios -> intentos
                //diccionario por ej, key = username, value = intentos
                _failedLogins = 0;
                CookieLogin(txtUser.Text);
                Response.Redirect("index.aspx");
            }
            else
            {
                WebformMessage.ShowMessage("El usuario o la contraseña son incorrectos" + _failedLogins, this);
                _failedLogins++;
            }
        }

        private void CookieLogin(string user)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,                             
                user,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,// Persistir la cookie de autenticación
                ""//rol?
            );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
        }
    }
}