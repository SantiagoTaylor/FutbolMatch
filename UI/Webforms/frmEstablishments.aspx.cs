using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmEstablishments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEstablishments();
            }
        }


        private void LoadEstablishments()
        {

            RepeaterEstablishments.DataSource = BLL_Establishment.GetEstablishments();
            RepeaterEstablishments.DataBind();
        }

        protected void Button_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modify")
            {
                Response.Redirect($"frmCreateEstablishment.aspx?id={e.CommandArgument.ToString()}");
            }
        }

        protected void ButtonRegisterEstablishment_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateEstablishment.aspx");
        }

        protected void ButtonDeleteConfirm_Click(object sender, EventArgs e)
        {
            BLL_Establishment.DeleteEstablishment(HiddenFieldEstablishmentID.Value);
            Response.Redirect(Request.RawUrl);

        }
    }
}