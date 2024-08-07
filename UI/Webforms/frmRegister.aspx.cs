﻿using BE;
using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                //Modificacion de usuario seleccionado
                if (Request.QueryString["username"] != null && Request.QueryString["modifyUser"] == null)
                {
                    TextBoxPassword.Visible = false;

                    LabelPassword.Visible = false;
                    LabelBlocked.Visible = true;
                    LabelRemoved.Visible = true;

                    CheckBoxBlocked.Visible = true;
                    CheckBoxRemoved.Visible = true;

                }
                //Modificacion de usuario seleccionado
                if (Request.QueryString["modifyUser"] != null)
                {
                    TextBoxPassword.Visible = true;

                    LabelPassword.Visible = true;
                    LabelBlocked.Visible = false;
                    LabelRemoved.Visible = false;
                    LabelRoles.Visible = false;

                    DropDownListRoles.Visible = false;

                    CheckBoxBlocked.Visible = false;
                    CheckBoxRemoved.Visible = false;

                }
                //Modificacion mis datos
                if (Request.QueryString["username"] != null)
                {
                    SetUserData(Request.QueryString["username"].ToString());
                    ButtonRegister.Text = "Modificar";
                    TextBoxUsername.ReadOnly = true;
                    LabelPassword.Visible = false;
                    TextBoxPassword.Visible = false;
                    SectionPasswordMod.Visible = true;
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
            DropDownListRoles.SelectedValue = user.Role;
            CheckBoxBlocked.Checked = user.Blocked;
            CheckBoxRemoved.Checked = user.Removed;
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
        private void EstablishmentsLoad()
        {
            DataTable establishments = BLL_Establishment.GetEstablishments();
            DataTable filteredTable = establishments.DefaultView.ToTable(false, "idEstablishment", "establishmentName");
            DropDownListEstablisments.DataTextField = "establishmentName";
            DropDownListEstablisments.DataValueField = "idEstablishment";
            DropDownListEstablisments.DataSource = filteredTable;
            DropDownListEstablisments.DataBind();
        }
        private bool ValidateFields()
        {
            if (TextBoxEmail.Text == "" || TextBoxUsername.Text == "" || TextBoxName.Text == "" || TextBoxLastname.Text == "")
            {
                WebformMessage.ShowMessage("Debe completar los campos solicitados", this);
                return false;
            }
            return true;
        }
        private bool ComparePassword()
        {
            if (Encrpyt.HashValue(TextBoxCurrentPass.Text) == SessionManager.GetInstance.User.Password)
            {
                if (TextBoxNwPass.Text == TextBoxConfirmPass.Text)
                {
                    return true;
                }
                else { WebformMessage.ShowMessage("Contraseñas no coinciden", this); }

            }
            else { WebformMessage.ShowMessage("Contraseña Incorrecta", this); }

            return false;
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            //Falta modificacion de establecimiento
            if (ValidateFields())
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
                    Console.WriteLine("1");
                    if (Request.QueryString["modifyUser"] != null)
                    {
                        Console.WriteLine("2");
                        if (CheckBoxModPass.Checked)
                        {
                            if (ComparePassword())
                            {
                                user.Password = Encrpyt.HashValue(TextBoxConfirmPass.Text);
                                BLL_User.UpdateMyAccount(user);
                                Response.Redirect("frmMyAccount.aspx");

                            }
                        }
                        else
                        {
                            BLL_User.UpdateUser(user);
                            Response.Redirect("frmMyAccount.aspx");
                        }

                    }
                    else
                    {
                        BLL_User.UpdateUser(user);
                        Response.Redirect("frmUsers.aspx");
                    }

                }
                else
                {
                    if (BLL_User.InsertUser(user))
                    {
                        //asocia usuario con estableclimiento
                        if (DropDownListRoles.SelectedItem.Text != "WEBMASTER")
                        {
                            if (BLL_Establishment.SetUserEstablishment(user.Username, DropDownListEstablisments.SelectedItem.Text))
                            {
                                Response.Redirect("frmUsers.aspx");
                            }
                            else
                            {
                                WebformMessage.ShowMessage($"No se asocio el usuario {user.Username} al esteblecimiento", this);
                            }

                        }
                        else
                        {
                            Response.Redirect("frmUsers.aspx");
                        }

                    }
                    else
                    {
                        WebformMessage.ShowMessage("Complete todos los campos", this);
                    }
                }
            }

        }

        protected void CheckBoxModPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxModPass.Checked)
            {
                PanelReqModPass.Visible = true;
            }
            else { PanelReqModPass.Visible = false; }
        }

        protected void DropDownListRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //POR AHORA
            if (DropDownListRoles.SelectedItem.Text != "WEBMASTER")
            {
                PanelEstablishments.Visible = true;
                EstablishmentsLoad();
            }
            else
            {
                PanelEstablishments.Visible = false;
            }
        }
    }
}