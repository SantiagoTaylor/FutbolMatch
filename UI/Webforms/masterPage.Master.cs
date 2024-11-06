using BLL;
using BE;
using SERVICES;
using System;
using System.Web.Security;
using System.Web.Services;
using System.Web;
using SERVICES.Languages;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace UI.Webforms
{
    public partial class a : System.Web.UI.MasterPage, IObserver
    {
        public List<Control> GetAllWebControls(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control control in parent.Controls)
            {
                if (control is WebControl)
                {
                    WebControl webControl = (WebControl)control;
                    controls.Add(webControl);
                }
                if (control.HasControls())
                {
                    controls.AddRange(GetAllWebControls(control));
                }
            }
            return controls;
        }


        public void Translate()
        {
            List<Control> controlList = GetAllWebControls(this);

            string webform = System.IO.Path.GetFileNameWithoutExtension(Server.MapPath("./masterPage.Master"));//mejorar
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

        protected void Page_Load(object sender, EventArgs e)
        {
            ObservableLanguage.Attach(this);
            try
            {
                Console.WriteLine(SessionManager.GetInstance.User.Role);
                switch (SessionManager.GetInstance.User.Role)
                {
                    case "WEBMASTER":
                        nav__webmaster.Visible = true;
                        break;
                    case "ADMIN":
                        nav__user__admin.Visible = true;
                        nav__admin.Visible = true;
                        break;
                    case "USER":
                        nav__user__admin.Visible = true;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }


        }

    }
}