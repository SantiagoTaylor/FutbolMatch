using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmMyEstablishment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeesLoad();
        }

        private void EmployeesLoad()
        {
            gvEmployees.DataSource = BLL_Establishment.GetEstablishmentUsers(SessionManager.GetInstance.User);
            gvEmployees.DataBind();
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmRegisterEmployee.aspx");
        }

    }
}