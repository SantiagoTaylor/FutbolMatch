using BE;
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
    public partial class frmCreateField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EstablishmentLoad();
        }

        private void EstablishmentLoad()
        {
            DropDownListEstablishment.DataTextField = "establishmentName";
            DropDownListEstablishment.DataValueField = "idEstablishment";
            DropDownListEstablishment.DataSource = BLL_Establishment.GetUserEstablishments(SessionManager.GetInstance.User);
            DropDownListEstablishment.DataBind();
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            //VALIDACIONES!!!
            BE_Field field = new BE_Field(TextBoxFieldName.Text, Convert.ToInt32(DropDownListSize.SelectedItem.Text), DropDownListFloorType.SelectedItem.Text, Convert.ToInt32(DropDownListEstablishment.SelectedValue));
            //EXCEPCIONES!!!
            BLL_Field.RegisterField(field);
        }
    }
}