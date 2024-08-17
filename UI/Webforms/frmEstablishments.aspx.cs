using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
            string idEstablishment = e.CommandArgument.ToString();

            if (e.CommandName == "Delete")
            {
                BLL_Establishment.DeleteEstablishment(e.CommandArgument.ToString());
                Response.Redirect(Request.RawUrl);
            }
            else if (e.CommandName == "Modify")
            {
                Response.Redirect($"frmCreateEstablishment.aspx?id={e.CommandArgument.ToString()}");
                //WebformMessage.ShowMessage(e.CommandArgument.ToString(),this);
            }
        }

        protected void ButtonRegisterEstablishment_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateEstablishment.aspx");
        }

    }
}