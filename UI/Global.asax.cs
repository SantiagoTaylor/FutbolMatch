using SERVICES;
using System;
using System.Web;
using System.Web.Security;

namespace UI
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // PARA SOLUCIONAR EL PROBLEMA DE LAS COOKIES Y EL SESSION MANAGER:
            // NO DEBERÍA HACERSE ASÍ. A PARTIR DE LA COOKIE DEBERÍA CREARSE EL SINGLETON
            // COOKIE -> DESENCRIPTAR -> OBTENER USUARIO -> CREAR SINGLETON
            // PERO NO ES SEGURO
            try
            {
                FormsAuthentication.SignOut();
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                authCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(authCookie);
                Response.Redirect(FormsAuthentication.LoginUrl);
            }
            catch (Exception)
            {
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            
        }

    }
}