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
    public partial class frmReserveField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetupTableHeader();
                EstablishmentLoad();
                FieldLoad();
            }
            ReservesLoad();
        }
        //Pruebas
        private void SetupTableHeader()
        {
            TableHeaderRow headerRow = new TableHeaderRow { CssClass = "tableheader" };

            headerRow.Cells.Add(new TableHeaderCell { Scope = TableHeaderScope.Column, Text = "ID" });
            headerRow.Cells.Add(new TableHeaderCell { Scope = TableHeaderScope.Column, Text = "Cancha" });
            headerRow.Cells.Add(new TableHeaderCell { Scope = TableHeaderScope.Column, Text = "Fecha" });
            headerRow.Cells.Add(new TableHeaderCell { Scope = TableHeaderScope.Column, Text = "Horario" });
            headerRow.Cells.Add(new TableHeaderCell { Scope = TableHeaderScope.Column, Text = "Empleado" });
            TableReserves.Rows.AddAt(0, headerRow); 
        }
        private void RegisterClientScript(string script)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
        private void ReservesLoad()
        {
            TableReserves.Rows.Clear();
            SetupTableHeader();
            var dtr = BLL_Reservation.GetReservations(DropDownListEstablishment.SelectedItem.Text);
            if (dtr != null)
            {
                foreach (DataRow r in dtr.Rows)
                {
                    TableRow tr = new TableRow();
                    tr.CssClass = "tablerow";
                    tr.Cells.Add(new TableCell { Text = r["idReservation"].ToString() });
                    tr.Cells.Add(new TableCell { Text = r["fieldName"].ToString() });
                    DateTime date = Convert.ToDateTime(r["date"]);
                    tr.Cells.Add(new TableCell { Text = date.ToString("dd/MM/yyyy") });
                    tr.Cells.Add(new TableCell { Text = r["startHour"].ToString() });
                    tr.Cells.Add(new TableCell { Text = r["username"].ToString() });
                    TableReserves.Rows.Add(tr);
                }
            }
            else
            {
                TableReserves.Rows.Clear();
                TableRow tr = new TableRow();
                TableCell tc = new TableCell
                {
                    ColumnSpan = 5,
                    Text = "Aun no hay reservas hechas",
                    CssClass = "table-reserves"
                };
                tr.Cells.Add(tc);
                TableReserves.Rows.Add(tr);
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
            ReservesLoad();
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
            DropDownListStartHour.DataSource = BLL_ReservationTimes.GetAvailableTimesByDate(Convert.ToInt32(DropDownListField.SelectedValue), TextBoxDate.Text);
            DropDownListStartHour.DataBind();
        }

        protected void ButtonReserve_Click(object sender, EventArgs e)
        {
            BE_Reservation reservation = new BE_Reservation(
                Convert.ToInt32(DropDownListField.SelectedValue),
                Convert.ToInt32(DropDownListStartHour.SelectedValue),
                SessionManager.GetInstance.User.Username,
                Convert.ToDateTime(TextBoxDate.Text));

            if (BLL_Reservation.RegisterReservation(reservation))
            {
                ReservesLoad();
            }
            else { WebformMessage.ShowMessage("Error: No se pa podido realizar la reserva correctamente", this); }
        }
    }
}