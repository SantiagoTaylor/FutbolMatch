using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGV();
                RolesLoad();
            }
        }

        private void RolesLoad()
        {
            DropDownListRole.DataTextField = "roleName";
            DropDownListRole.DataValueField = "idRole";
            DropDownListRole.DataSource = BLL_Role.GetRoles();
            DropDownListRole.DataBind();
        }

        private void UpdateGVFilter()
        {
            DataTable table = BLL_User.GetUsers();
            DataView view = new DataView(table);
            string filter = "1=1";
            if (CheckBoxUsername.Checked && !string.IsNullOrEmpty(TextBoxUsername.Text))
            {
                filter += $" AND Usuario = '{TextBoxUsername.Text}'";
            }
            if (CheckBoxRole.Checked)
            {
                filter += $" AND Rol = '{DropDownListRole.SelectedItem.Text}'";
            }
            if (CheckBoxBlocked.Checked)
            {
                filter += $" AND Bloqueado = '{(CheckBoxBlocked.Checked ? 1 : 0)}'";
            }
            if (CheckBoxRemoved.Checked)
            {
                filter += $" AND Borrado = '{(CheckBoxRemoved.Checked ? 1 : 0)}'";
            }
            ViewState["usersFilter"] = filter;
            view.RowFilter = filter;
            gvUsers.DataSource = view;
            gvUsers.DataBind();
        }

        protected void ButtonRegisterEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmRegister.aspx");
        }
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string username = btn.CommandArgument;
            
            Response.Redirect($"frmRegister.aspx?username={username}");
        }
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string username = btn.CommandArgument;
            BLL_User.DeleteUser(username);
            UpdateGV();

        }
        private void UpdateGV() {
            gvUsers.DataSource = BLL_User.GetUsers();
            gvUsers.DataBind();
        }

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            //UpdateGV();
        }

        protected void CheckBoxUsername_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxUsername.Enabled = CheckBoxUsername.Checked;
        }

        protected void ButtonFilter_Click(object sender, EventArgs e)
        {
            UpdateGVFilter();
        }

        protected void CheckBoxRole_CheckedChanged(object sender, EventArgs e)
        {
            DropDownListRole.Enabled = CheckBoxRole.Checked;
        }
    }
}