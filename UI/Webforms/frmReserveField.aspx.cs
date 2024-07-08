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
    public partial class frmReserveField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EstablishmentLoad();
                FieldLoad();
            }
        }

        private void EstablishmentLoad()
        {
            DropDownListEstablishment.DataTextField = "establishmentName";
            DropDownListEstablishment.DataValueField = "idEstablishment";
            if (SessionManager.GetInstance.User.Role == "ADMIN")
            {
                DropDownListEstablishment.DataSource = BLL_Establishment.GetUserEstablishments(SessionManager.GetInstance.User);
            }
            else
            {
                DropDownListEstablishment.DataSource = BLL_Establishment.GetEstablishments();
            }
            DropDownListEstablishment.DataBind();
        }

        protected void DropDownListEstablishment_SelectedIndexChanged(object sender, EventArgs e)
        {
            FieldLoad();
        }

        private void FieldLoad()
        {
            //ESTA MAL... LOS NOMBRES NO DEBERIAN CAMBIARSE EN EL SP
            DropDownListField.Items.Clear();
            DropDownListField.DataTextField = "Nombre";
            DropDownListField.DataValueField = "ID";
            DropDownListField.DataSource = BLL_Field.GetEstablishmentFields(Convert.ToInt32(DropDownListEstablishment.SelectedValue));
            DropDownListField.DataBind();
        }

        protected void TextBoxDate_TextChanged(object sender, EventArgs e)
        {
            DropDownListStartHour.DataTextField = "startHour";
            DropDownListStartHour.DataValueField = "idReservationTimes";
            DropDownListStartHour.DataSource = BLL_ReservationTimes.GetAvailableTimesByDate(Convert.ToInt32(DropDownListField.SelectedValue),TextBoxDate.Text);
            DropDownListStartHour.DataBind();
        }

        protected void ButtonReserve_Click(object sender, EventArgs e)
        {
            //hacer reserva
            BE_Reservation reservation = new BE_Reservation(Convert.ToInt32(DropDownListField.SelectedValue), Convert.ToInt32(DropDownListStartHour.SelectedValue), SessionManager.GetInstance.User.Username, DateTime.Today);
            BLL_Reservation.RegisterReservation(reservation);
            WebformMessage.ShowMessage("Se realizó la reserva con éxito", this);

        }
    }
}