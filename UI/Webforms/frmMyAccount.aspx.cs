using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmMyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LabelRUsername.Text = SessionManager.GetInstance.User.Username;
                LabelRName.Text = SessionManager.GetInstance.User.Name;
                LabelRLastname.Text = SessionManager.GetInstance.User.Lastname;
                LabelREmail.Text = SessionManager.GetInstance.User.Email;
                LabelRPhone.Text = SessionManager.GetInstance.User.Phone.ToString();
            }
        }

        protected void ButtonChangeMyData_Click(object sender, EventArgs e)
        {
            Response.Redirect($"frmRegister.aspx?modifyUser=true&username={SessionManager.GetInstance.User.Username}");
        }
    }
}