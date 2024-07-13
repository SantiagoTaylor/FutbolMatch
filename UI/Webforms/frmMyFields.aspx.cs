using BLL;
using SERVICES;
using System;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmMyFields : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EstablishmentLoad();
                FieldsLoad();
            }
        }
        private void EstablishmentLoad()
        {
            DropDownListEstablishment.DataTextField = "establishmentName";
            DropDownListEstablishment.DataValueField = "idEstablishment";
            DropDownListEstablishment.DataSource = BLL_Establishment.GetUserEstablishments(SessionManager.GetInstance.User);
            DropDownListEstablishment.DataBind();
        }
        private void FieldsLoad()
        {
            gvFields.DataSource = BLL_Field.GetEstablishmentFields(Convert.ToInt32(DropDownListEstablishment.SelectedValue));
            gvFields.DataBind();
        }
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            //FALTA!!!
            //LinkButton btn = (LinkButton)sender;
            //string username = btn.CommandArgument;

            //Response.Redirect($"frmRegister.aspx?username={username}");
        }
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            //LinkButton btn = (LinkButton)sender;
            //string username = btn.CommandArgument;
            //BLL_User.DeleteUser(username);
            FieldsLoad();

        }
        protected void gvFields_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonCreateField_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateField.aspx");
        }
    }
}