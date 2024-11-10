using BE;
using BLL;
using Newtonsoft.Json;
using SERVICES;
using SERVICES.Languages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmEstablishments : System.Web.UI.Page, IObserver
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEstablishments();
                ObservableLanguage.Attach(this);
            }
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

        private void LoadEstablishments()
        {
            RepeaterEstablishments.DataSource = BLL_Establishment.GetEstablishments();
            RepeaterEstablishments.DataBind();
        }

        //Endpoint
        [WebMethod]
        public static string GetDataEstablishment(string a)
        {
            var est = BLL_Establishment.GetEstablishment(a);
            est.Id = int.Parse(a);
            est.Employees = BLL_Establishment.GetEstablishmentUsers(int.Parse(a)).Rows.Cast<DataRow>()
                .Select(row => new BE_User
                {
                    Username = row["Usuario"].ToString(),
                    Name = row["Nombre"].ToString(),
                    Lastname = row["Apellido"].ToString(),
                    Email = row["Mail"].ToString(),
                    Phone = row["Telefono"].ToString(),
                    Role = row["Rol"].ToString(),
                    Language = row["Idioma"] != DBNull.Value && int.TryParse(row["Idioma"].ToString(), out int lang) ? lang : 0,
                    Blocked = Convert.ToBoolean(row["Bloqueado"]),
                    Removed = Convert.ToBoolean(row["Borrado"])
                })
                .ToList();

            est.Fields = BLL_Field.GetEstablishmentFields(int.Parse(a)).Rows.Cast<DataRow>()
                .Select(row => new BE_Field(
                    int.Parse(row["ID"].ToString()),
                    row["Nombre"].ToString(),
                    int.Parse(row["Tamaño"].ToString()),
                    row["Piso"].ToString(),
                    int.Parse(a)))
                .ToList();

            return JsonConvert.SerializeObject(est, Formatting.Indented);
        }

        [WebMethod]
        public static void DeleteUser(string username)
        {
            BLL_User.DeleteUser(username);
        }

        protected void Button_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modify")
            {
                Response.Redirect($"frmCreateEstablishment.aspx?id={e.CommandArgument.ToString()}");
            }
        }

        protected void ButtonRegisterEstablishment_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateEstablishment.aspx");
        }

        protected void ButtonDeleteConfirm_Click(object sender, EventArgs e)
        {
            BLL_Establishment.DeleteEstablishment(HiddenFieldEstablishmentID.Value);
            Response.Redirect(Request.RawUrl);
        }

        protected void TextBoxNameEstablishment_TextChanged(object sender, EventArgs e)
        {
            RepeaterEstablishments.DataSource = BLL_Establishment.GetEstablishments()
                .AsEnumerable()
                .Where(row => row.Field<string>("establishmentName").ToLower().Contains(TextBoxNameEstablishment.Text.ToLower().ToString()))
                .CopyToDataTable();
            RepeaterEstablishments.DataBind();
        }
    }
}