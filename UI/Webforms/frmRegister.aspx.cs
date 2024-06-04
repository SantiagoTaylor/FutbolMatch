using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;
using SERVICES;

namespace UI.Webforms
{
    public partial class frmRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TextBoxPassword.Visible = true;
            //LabelPassword.Visible = true;
            if (!Page.IsPostBack)
            {
                RolesLoad();
                if (Request.QueryString["username"] != null)
                {
                    BE_User user = BLL_User.GetUser(Request.QueryString["username"].ToString());
                    TextBoxName.Text = user.Name;
                    TextBoxLastname.Text = user.Lastname;
                    TextBoxUsername.Text = user.Username;
                    TextBoxUsername.ReadOnly = true;
                    TextBoxPhone.Text = user.Phone.ToString();
                    TextBoxPassword.Visible = false;
                    LabelPassword.Visible = false;
                    TextBoxEmail.Text = user.Email;
                    DropDownListRoles.SelectedValue = user.Role;
                    ButtonRegister.Text = "Modificar";
                }
            }
        }

        private void RolesLoad()
        {
            DropDownListRoles.DataTextField = "roleName";
            DropDownListRoles.DataValueField = "idRole";
            DropDownListRoles.DataSource = BLL_Role.GetRoles();
            DropDownListRoles.DataBind();
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            BE_User user = new BE_User(
                TextBoxUsername.Text,
                Encrpyt.HashPassword(TextBoxPassword.Text),
                TextBoxName.Text,
                TextBoxLastname.Text,
                TextBoxEmail.Text,
                Convert.ToInt32(TextBoxPhone.Text),
                DropDownListRoles.SelectedItem.Text);

            if (Request.QueryString["username"] != null)
            {
                BLL_User.UpdateUser(user);
                Response.Redirect("frmUsers.aspx");
            }
            else
            {
                if (BLL_User.SaveUser(user))
                {
                    Response.Redirect("frmUsers.aspx");
                }
                else
                {
                    WebformMessage.ShowMessage("Complete todos los campos", this);
                    //FALSA VALIDACION!!! HACER VALIDACION
                }
            }
        }
    }
}