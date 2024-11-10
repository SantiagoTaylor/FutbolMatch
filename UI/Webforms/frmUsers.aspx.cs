using BLL;
using SERVICES;
using SERVICES.Languages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmUsers : System.Web.UI.Page, IObserver
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObservableLanguage.Attach(this);
                UpdateGV();
                RolesLoad();
            }
        }

        public void Translate()
        {
            List<Control> controlList = Translation.GetAllWebControls(this);

            string webform = System.IO.Path.GetFileNameWithoutExtension(Server.MapPath(Page.AppRelativeVirtualPath));
            Dictionary<string, string> translations = Translation.GetTranslation(SessionManager.GetInstance.User.Language);

            foreach (Control control in controlList)
            {
                string key = $"{webform}_{control.ID}";
                if (translations.ContainsKey(key))
                {
                    if (control is Button)
                    {
                        ((Button)control).Text = translations[key];
                    }
                    else if (control is Label)
                    {
                        ((Label)control).Text = translations[key];
                    }
                    else if (control is Literal)
                    {
                        ((Literal)control).Text = translations[key];
                    }
                }
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
            if (BLL_User.DeleteUser(username)) WebformMessage.ShowMessage($"El usuario {username} se elimino correctamente", this);
            UpdateGV();
        }
        private void UpdateGV()
        {
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