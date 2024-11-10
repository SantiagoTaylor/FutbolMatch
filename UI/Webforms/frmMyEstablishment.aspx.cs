using BLL;
using Newtonsoft.Json;
using SERVICES;
using System;
using System.Data;
using System.Linq;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmMyEstablishment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GetDataMyEstablishment()
        {
            return JsonConvert.SerializeObject(
            BLL_Establishment.GetEstablishmentDetailsByUsername(SessionManager.GetInstance.User)
            .Select(est => new
            {
                est.Id,
                est.Name,
                est.Email,
                est.Phone,
                est.Address,
                Employees = est.Employees.Where(emp => !emp.Removed).ToList(),
                est.Fields
            }).ToList(),
            Formatting.Indented);
        }

        [WebMethod]
        public static void DeleteUser(string username)
        {
            BLL_User.DeleteUser(username);
        }
    }
}