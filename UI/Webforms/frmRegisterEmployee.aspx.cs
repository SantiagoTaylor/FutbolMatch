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
            if (!Page.IsPostBack)
            {
                LanguageLoad();
            }
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
                "USER",
                Convert.ToInt32(DropDownListLanguage.SelectedValue));

            BLL_User.InsertUser(user);
            /*ERROR PUEDE HABER QUE UN ADMIN QUIERA REGISTRAR UN EMPLEADO PERO ESE ADMIN TIENE MAS ESTABLECIMIENTOS. 
             * AGREGAR UN DROPLIST DE LOS ESTABLECIMIENTOS*/
            BLL_Establishment.SetUserEstablishment(user.Username, BLL_Establishment.GetEstablishmentName(SessionManager.GetInstance.User.Username));
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