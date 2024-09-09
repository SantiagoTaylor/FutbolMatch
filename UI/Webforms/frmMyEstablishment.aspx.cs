using BE;
using BLL;
using Newtonsoft.Json;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmMyEstablishment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GetDataMyEstablishment() {
            
            return JsonConvert.SerializeObject
                (BLL_Establishment.GetEstablishmentDetailsByUsername(SessionManager.GetInstance.User), 
                Formatting.Indented);

        }


    }
}