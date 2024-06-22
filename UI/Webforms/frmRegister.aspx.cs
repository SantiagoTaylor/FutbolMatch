using BE;
using BLL;
using SERVICES;
using System;
using System.Web.UI;

namespace UI.Webforms
{
    public partial class frmRegister : System.Web.UI.Page
    {
        //Validar Campos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RolesLoad();
                LanguageLoad();
                if (Request.QueryString["username"] != null)
                {
                    BE_User user = BLL_User.GetUserByUsername(Request.QueryString["username"].ToString());
                    TextBoxName.Text = user.Name;
                    TextBoxLastname.Text = user.Lastname;
                    TextBoxUsername.Text = user.Username;
                    TextBoxPhone.Text = user.Phone;
                    TextBoxEmail.Text = user.Email;
                    DropDownListRoles.SelectedValue = user.Role;
                    CheckBoxBlocked.Checked = user.Blocked;
                    CheckBoxRemoved.Checked = user.Removed;
                    TextBoxUsername.ReadOnly = true;
                    TextBoxPassword.Visible = false;
                    LabelPassword.Visible = false;
                    LabelBlocked.Visible = true;
                    LabelRemoved.Visible = true;
                    CheckBoxBlocked.Visible = true;
                    CheckBoxRemoved.Visible = true;
                    ButtonRegister.Text = "Modificar";
                }
            }
        }

        private void LanguageLoad()
        {
            DropDownListLanguage.DataTextField = "languageName";
            DropDownListLanguage.DataValueField = "idLanguage";
            DropDownListLanguage.DataSource = BLL_Language.GetLanguages();
            DropDownListLanguage.DataBind();
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
                Encrpyt.HashValue(TextBoxPassword.Text),
                TextBoxName.Text,
                TextBoxLastname.Text,
                TextBoxEmail.Text,
                TextBoxPhone.Text,
                DropDownListRoles.SelectedItem.Text,
                DropDownListLanguage.SelectedItem.Text,
                CheckBoxBlocked.Checked,
                CheckBoxRemoved.Checked);

            if (Request.QueryString["username"] != null)
            {
                BLL_User.UpdateUser(user);
                Response.Redirect("frmUsers.aspx");
            }
            else
            {
                if (BLL_User.InsertUser(user))
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