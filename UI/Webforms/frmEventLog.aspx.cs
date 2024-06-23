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
                UpdateGV(null);
                foreach (DataRow item in BLL_EventLog.GetActivityLevel(SessionManager.GetInstance.User.Language).Rows)
                {
                    DropDownListActivityLevels.Items.Add(item["levelName"].ToString());
                }
            }
        }
        private void UpdateGV(DataTable dt)
        {
            if (dt == null)
            {
                gvEventLog.DataSource = BLL_EventLog.GetEventLog();
            }
            else
            {
                gvEventLog.DataSource = dt;
            }            
            gvEventLog.DataBind();
        }
        protected void gvEventLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEventLog.PageIndex = e.NewPageIndex;
            UpdateGV(Session["FilteredDataTable"] as DataTable);
        }

        protected void DropDownListFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvEventLog.DataSource = BLL_EventLog.GetEventLogFilter(1);
            gvEventLog.DataBind();
        }

        protected void TextBoxUsername_TextChanged(object sender, EventArgs e)
        {
            Session["Username"] = TextBoxUsername.Text;
            if (CheckBoxUsername.Checked)
            {
                UpdateGV(BLL_EventLog.GetEventLogFilter(0));
            }
        }
    }
}