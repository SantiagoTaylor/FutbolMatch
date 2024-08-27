using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Script.Services;
using BE;
using System.Web.Script.Serialization;
using System.Drawing;

namespace UI.Webforms
{
    public partial class frmEstablishments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEstablishments();
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
                    Language = row["Idioma"].ToString(),
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
    }
}