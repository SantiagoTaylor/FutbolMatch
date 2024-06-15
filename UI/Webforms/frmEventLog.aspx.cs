using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Data;
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
            foreach (DataRow item in BLL_EventLog.GetActivityLevel(SessionManager.GetInstance.User.Language).Rows) {
                DropDownListActivityLevels.Items.Add(item["levelName"].ToString());
            }
        }
        private void UpdateGV()
        {
            gvEventLog.DataSource = BLL_EventLog.GetEventLog(-1);
            gvEventLog.DataBind();
        }
        protected void gvEventLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEventLog.PageIndex = e.NewPageIndex;
            UpdateGV();
        }

        protected void DropDownListFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvEventLog.DataSource=BLL_EventLog.GetEventLog(DropDownListFilters.SelectedIndex);
            gvEventLog.DataBind();
        }

    }
}