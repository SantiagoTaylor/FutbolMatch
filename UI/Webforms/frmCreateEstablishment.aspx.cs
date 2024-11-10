using BE;
using BLL;
using SERVICES;
using SERVICES.Languages;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmCreateEstablishment : System.Web.UI.Page, IObserver
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ObservableLanguage.Attach(this);
                if (Request.QueryString["id"] != null)
                {
                    LoadDataEstablishment(Request.QueryString["id"].ToString());
                    ButtonRegister.Text = "Modificar";
                }
            }
        }
        private void LoadDataEstablishment(string id)
        {
            BE_Establishment establishment = BLL_Establishment.GetEstablishment(id);
            TextBoxName.Text = establishment.Name;
            TextBoxEmail.Text = establishment.Email;
            TextBoxPhone.Text = establishment.Phone;
            TextBoxAdress.Text = establishment.Address;
            
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            BE_Establishment establishment = new BE_Establishment(TextBoxName.Text, TextBoxEmail.Text, TextBoxPhone.Text, TextBoxAdress.Text);
            if (ButtonRegister.Text == "Modificar")
            {
                establishment.Id = int.Parse(Request.QueryString["id"].ToString());
                if (BLL_Establishment.UpdateEstablishment(establishment)) Response.Redirect("frmEstablishments.aspx");
            }
            else
            {
                if (BLL_Establishment.RegisterEstablishment(establishment)) Response.Redirect("frmEstablishments.aspx");
            }
        }

        public void Translate()
        {
            List<Control> controlList = Translation.GetAllWebControls(this);

            string webform = System.IO.Path.GetFileNameWithoutExtension(Server.MapPath(Page.AppRelativeVirtualPath));
            var translations = Translation.GetTranslation(SessionManager.GetInstance.User.Language);

            var controlHandlers = new Dictionary<Type, Action<Control, string>>
            {
                { typeof(Button), (ctrl, text) => ((Button)ctrl).Text = text },
                { typeof(Label), (ctrl, text) => ((Label)ctrl).Text = text },
                { typeof(Literal), (ctrl, text) => ((Literal)ctrl).Text = text },
                { typeof(HyperLink), (ctrl, text) => ((HyperLink)ctrl).Text = text }
            };

            foreach (var control in controlList)
            {
                string key = $"{webform}_{control.ID}";
                if (translations.ContainsKey(key) && controlHandlers.ContainsKey(control.GetType()))
                {
                    controlHandlers[control.GetType()].Invoke(control, translations[key]);
                }
            }
        }
    }
}