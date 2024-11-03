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
                    else if (control is HyperLink)
                    {
                        ((HyperLink)control).Text = translations[key];
                    }
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