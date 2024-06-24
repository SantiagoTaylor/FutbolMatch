using BLL;
using SERVICES;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmEventLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGV();
                foreach (DataRow item in BLL_EventLog.GetActivityLevel(SessionManager.GetInstance.User.Language).Rows)
                {
                    DropDownListActivityLevels.Items.Add(item["levelName"].ToString());
                }
            }
        }
        private void UpdateGV()
        {
            gvEventLog.DataSource = BLL_EventLog.GetEventLog();
            gvEventLog.DataBind();
        }

        protected void gvEventLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEventLog.PageIndex = e.NewPageIndex;
            UpdateGV();
        }
    }
}