﻿using BE;
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
                DropDownListLanguage.Text);

            BLL_User.InsertUser(user);
        }
        private void LanguageLoad()
        {
            DropDownListLanguage.DataTextField = "languageName";
            DropDownListLanguage.DataValueField = "idLanguage";
            DropDownListLanguage.DataSource = BLL_Language.GetLanguages();
            DropDownListLanguage.DataBind();
        }

    }
}