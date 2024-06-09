using BE;
using BLL;
using SERVICES;
using System;
using System.Web.UI;

namespace UI.Webforms
{
    public partial class frmRegister : System.Web.UI.Page
    {
        //Validad Campos
        protected void Page_Load(object sender, EventArgs e)
        {
            //TextBoxPassword.Visible = true;
            //LabelPassword.Visible = true;
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
                    TextBoxUsername.ReadOnly = true;
                    TextBoxPhone.Text = user.Phone;
                    TextBoxPassword.Visible = false;
                    LabelPassword.Visible = false;
                    TextBoxEmail.Text = user.Email;
                    DropDownListRoles.SelectedValue = user.Role;
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
                Encrpyt.HashPassword(TextBoxPassword.Text),
                TextBoxName.Text,
                TextBoxLastname.Text,
                TextBoxEmail.Text,
                TextBoxPhone.Text,
                DropDownListRoles.SelectedItem.Text,
                "Español");//FALTA combo box de idioma, esta hardcodeado!!!

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