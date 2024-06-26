﻿using BE;
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
    public partial class frmUsers : System.Web.UI.Page
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
    }
}