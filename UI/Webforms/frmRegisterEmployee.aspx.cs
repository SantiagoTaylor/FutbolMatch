using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SERVICES;

namespace UI.Webforms
{
    public partial class frmRegisterEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!Page.IsPostBack)
            {
                LanguageLoad();
                if (Request.QueryString["username"] != null)
                {
                    SetUserData(Request.QueryString["username"]);
                    ButtonRegister.Text = "Modificar";
                    TextBoxUsername.ReadOnly = true;
                }
            }
        }

        private void SetUserData(string username)
        {
            BE_User user = BLL_User.GetUserByUsername(username);
            TextBoxName.Text = user.Name;
            TextBoxLastname.Text = user.Lastname;
            TextBoxUsername.Text = user.Username;
            TextBoxPhone.Text = user.Phone;
            TextBoxEmail.Text = user.Email;
            LabelBlocked.Visible = true;
            DropDownListLanguage.SelectedValue = user.Language;
            CheckBoxBlocked.Visible = true;
            CheckBoxBlocked.Checked = user.Blocked;
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            var user = new BE_User(
                TextBoxUsername.Text,
                Encrpyt.HashValue(TextBoxPassword.Text),
                TextBoxName.Text,
                TextBoxLastname.Text,
                TextBoxEmail.Text,
                TextBoxPhone.Text,
                "USER",
                Convert.ToInt32(DropDownListLanguage.SelectedValue));

            if (Request.QueryString["username"] == null)
            {

                BLL_User.InsertUser(user);
                /*ERROR PUEDE HABER QUE UN ADMIN QUIERA REGISTRAR UN EMPLEADO PERO ESE ADMIN TIENE MAS ESTABLECIMIENTOS. 
                 * AGREGAR UN DROPLIST DE LOS ESTABLECIMIENTOS*/
                BLL_Establishment.SetUserEstablishment(user.Username, BLL_Establishment.GetEstablishmentName(SessionManager.GetInstance.User.Username));
            }
            else
            {
                try
                {
                    if (BLL_User.UpdateUser(user)) Response.Redirect("frmMyEstablishment.aspx");
                }
                catch (Exception ex)
                {
                    WebformMessage.ShowMessage(ex.Message, this);
                }
            }

        }
        private void LanguageLoad()
        {
            DropDownListLanguage.DataTextField = "languageDisplay";
            DropDownListLanguage.DataValueField = "idLanguage";
            DropDownListLanguage.DataSource = BLL_Language.GetLanguages();
            DropDownListLanguage.DataBind();
        }

    }
}