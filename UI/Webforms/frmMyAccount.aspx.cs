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
    public partial class frmMyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LabelRUsername.Text = SessionManager.GetInstance.User.Username;
                LabelRName.Text = SessionManager.GetInstance.User.Name;
                LabelRLastname.Text = SessionManager.GetInstance.User.Lastname;
                LabelREmail.Text = SessionManager.GetInstance.User.Email;
                LabelRPhone.Text = SessionManager.GetInstance.User.Phone.ToString();
                ReservationLoad();
            }
        }

        private void ReservationLoad()
        {
            if (SessionManager.GetInstance.User.Role == "USER")
            {
                //gvReservations.DataSource = BLL_Reservation.GetUserReservations(SessionManager.GetInstance.User);
                //gvReservations.DataBind();
            }
            else if (SessionManager.GetInstance.User.Role == "ADMIN")
            {
                //reservas de hoy, por ejemplo
            }
        }

        protected void ButtonChangeMyData_Click(object sender, EventArgs e)
        {
            Response.Redirect($"frmRegister.aspx?modifyUser=true&username={SessionManager.GetInstance.User.Username}");
        }
    }
}