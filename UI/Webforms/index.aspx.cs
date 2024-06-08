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
    }
}