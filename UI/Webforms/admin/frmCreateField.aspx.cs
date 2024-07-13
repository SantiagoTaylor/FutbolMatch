using BE;
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
    public partial class frmCreateField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EstablishmentLoad();
                ReservationTimesLoad();
            }
        }

        private void ReservationTimesLoad()
        {
            DataTable reservationTimes = BLL_ReservationTimes.GetReservationTimes();
            DropDownListStartHour.DataTextField = "startHour";
            DropDownListStartHour.DataValueField = "idReservationTimes";
            DropDownListStartHour.DataSource = reservationTimes;
            DropDownListStartHour.DataBind();
            DropDownListEndHour.DataTextField = "endHour";
            DropDownListEndHour.DataValueField = "idReservationTimes";
            DropDownListEndHour.DataSource = reservationTimes;
            DropDownListEndHour.DataBind();
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
            BLL_ReservationTimes.RegisterFieldReservationTimes(Convert.ToInt32(DropDownListStartHour.SelectedValue), Convert.ToInt32(DropDownListEndHour.SelectedValue), BLL_Field.GetFieldID(field));
        }
    }
}