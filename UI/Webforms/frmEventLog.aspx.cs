using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmEventLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateGV();
        }
        private void UpdateGV()
        {
            gvEventLog.DataSource = BLL_EventLog.GetEventLog();
            gvEventLog.DataBind();
        }
    }
}