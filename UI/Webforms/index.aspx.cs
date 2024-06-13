using BE;
using BLL;
using SERVICES;
using System;
using System.Web;
using System.Web.Security;

namespace UI.Webforms
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if (SessionManager.GetInstance != null)
                {
                    BE_User user = SessionManager.GetInstance.User;
                    prueba.Text = user.Username +
                        user.Password +
                        user.Name +
                        user.Lastname +
                        user.Email +
                        user.Phone +
                        user.Role +
                        user.Language;
                }
            }
			catch (Exception)
			{
			}
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            BLL_Login.Logout();
            FormsAuthentication.SignOut();
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            authCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(authCookie);
            Response.Redirect(FormsAuthentication.LoginUrl);
        }
    }
}