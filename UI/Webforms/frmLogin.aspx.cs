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
                _failedLogins = 0;
                Response.Redirect("index.aspx");
                CookieLogin(txtUser.Text);
            }
            else
            {
                WebformMessage.ShowMessage("El usuario o la contraseña son incorrectos" + _failedLogins, this);
                _failedLogins++;
            }
        }

        private void CookieLogin(string user)
        {
            // Crear el ticket de autenticación
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,                             // Versión del ticket
                user,                      // Nombre de usuario
                DateTime.Now,                  // Fecha y hora de emisión
                DateTime.Now.AddMinutes(30),   // Fecha y hora de expiración
                false,    // Persistir la cookie de autenticación
                ""                             // Información adicional (puedes añadir roles u otra información)
            );

            // Encriptar el ticket
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            // Crear la cookie de autenticación
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            // Añadir la cookie de autenticación a la respuesta
            Response.Cookies.Add(authCookie);
        }
    }
}