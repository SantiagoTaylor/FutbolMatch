using SERVICES;
using SERVICES.Languages;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmMyAccount : System.Web.UI.Page, IObserver
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ObservableLanguage.Attach(this);
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

        public void Translate()
        {
            List<Control> controlList = Translation.GetAllWebControls(this);

            string webform = System.IO.Path.GetFileNameWithoutExtension(Server.MapPath(Page.AppRelativeVirtualPath));
            Dictionary<string, string> translations = Translation.GetTranslation(SessionManager.GetInstance.User.Language);

            foreach (Control control in controlList)
            {
                string key = $"{webform}_{control.ID}";
                if (translations.ContainsKey(key))
                {
                    if (control is Button)
                    {
                        ((Button)control).Text = translations[key];
                    }
                    else if (control is Label)
                    {
                        ((Label)control).Text = translations[key];
                    }
                    else if (control is Literal)
                    {
                        ((Literal)control).Text = translations[key];
                    }
                }
            }
        }
    }
}