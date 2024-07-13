using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmMyEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EstablishmentLoad();
                EmployeesLoad();
            }
        }

        private void EstablishmentLoad()
        {
            DropDownListEstablishment.DataTextField = "establishmentName";
            DropDownListEstablishment.DataValueField = "idEstablishment";
            DropDownListEstablishment.DataSource = BLL_Establishment.GetUserEstablishments(SessionManager.GetInstance.User);
            DropDownListEstablishment.DataBind();
        }

        private void EmployeesLoad()
        {
            gvMyEmployees.DataSource = BLL_Establishment.GetEstablishmentUsers(Convert.ToInt32(DropDownListEstablishment.SelectedValue));
            gvMyEmployees.DataBind();
        }

        protected void DropDownListEstablishment_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeesLoad();
        }
    }
}