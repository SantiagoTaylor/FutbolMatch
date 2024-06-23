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
            UpdateGV(null);
            foreach (DataRow item in BLL_EventLog.GetActivityLevel(SessionManager.GetInstance.User.Language).Rows)
            {
                DropDownListActivityLevels.Items.Add(item["levelName"].ToString());
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
            UpdateGV(null);
        }

        protected void DropDownListFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvEventLog.DataSource = BLL_EventLog.GetEventLogFilter(0);
            gvEventLog.DataBind();
        }

        protected void TextBoxUser_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBoxDate_TextChanged(object sender, EventArgs e)
        {
            string dateString = TextBoxDate.Text;
            DateTime sltDate;
            if (DateTime.TryParse(dateString, out sltDate))
            {
                DataRow[] fltRows = BLL_EventLog._dt.Select($"eventDate = #{sltDate.ToString("yyyy-MM-dd")}#");
                DataTable dtFlt = BLL_EventLog._dt.Clone();

                foreach (DataRow row in fltRows)
                {
                    dtFlt.ImportRow(row);
                }
                UpdateGV(dtFlt);
            }
        }
    }
}