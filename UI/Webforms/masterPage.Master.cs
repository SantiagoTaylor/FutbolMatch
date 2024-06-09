using BE;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class a : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(SessionManager.GetInstance.User.Role);
                switch (SessionManager.GetInstance.User.Role)
                {
                    case "WEBMASTER":
                        nav__webmaster.Visible = true;
                        break;
                    case "ADMIN":
                        nav__user__admin.Visible = true;
                        nav__admin.Visible = true;
                        break;
                    case "USER":
                        nav__user__admin.Visible = true;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }


        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {

        }
    }
}