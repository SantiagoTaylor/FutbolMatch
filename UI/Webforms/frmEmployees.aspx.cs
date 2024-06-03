using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateGV();
        }

        protected void ButtonRegisterEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmRegister.aspx");
        }
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idEmploye = btn.CommandArgument;
            
            Response.Redirect($"frmRegister.aspx?idEmploye={idEmploye}");
        }
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            if (BLL_Employee.DeleteEmployee(btn.CommandArgument))
            {
                UpdateGV();
            }
            else {
                
            }

        }
        private void UpdateGV() {
            GridView1.DataSource = BLL_Employee.GetEmployees();
            GridView1.DataBind();
        }
    }
}