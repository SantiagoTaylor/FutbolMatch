using BLL;
using System;
using SERVICES;
using System.Web.Security;
using System.Web;
using System.Collections.Generic;
using System.Web.SessionState;

namespace UI.Webforms
{
    public partial class frmLogin : System.Web.UI.Page
    {
        private static Dictionary<string, int> _failedLogins = new Dictionary<string, int>();
        //usuario - intentos
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            /*if (!VerifyIntegrity())
            {
                Response.Redirect("frmErrorPage.aspx");
            }*/
            if (BLL_Login.IsValidCredentials(txtUser.Text, txtPassword.Text))
            {
                CookieLogin(txtUser.Text);
                //Roles.AddUserToRole(txtUser.Text, SessionManager.GetInstance.User.Role);
                Response.Redirect("frmMyAccount.aspx");
            }
            else
            {
                //tiene que ser distinto y guardar un seguimiento de usuarios -> intentos
                //diccionario por ej, key = username, value = intentos
                if (_failedLogins.TryGetValue(txtUser.Text, out int _fails))
                {
                    _failedLogins[txtUser.Text] += 1;
                    if (_failedLogins[txtUser.Text] >= 3)
                    {
                        //bloquear cuenta
                        BLL_User.BlockUser(txtUser.Text);
                        WebformMessage.ShowMessage("Tu cuenta ha sido bloqueada.", this);
                    }
                }
                else
                {
                    _failedLogins.Add(txtUser.Text, 1);
                }
                //si se bloquea no mostrar (o si)
                WebformMessage.ShowMessage("El usuario o la contraseña son incorrectos " + _failedLogins[txtUser.Text], this);
            }
        }

        private void CookieLogin(string username)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                username,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,// Persistir la cookie: se persiste igual (?!?!)
                ""//rol?
            );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
        }

        private bool VerifyIntegrity()
        {
            var tablesAndErrors = DatabaseIntegrity.HorizontalIntegrity();
            foreach (var item in tablesAndErrors)
            {
                if (item.Value.Count != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}