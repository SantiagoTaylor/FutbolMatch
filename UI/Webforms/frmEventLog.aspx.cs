using BLL;
using SERVICES;
using System;
using System.Collections.Generic;
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
                ActivityLevelsLoad();
                ActivitysLoad();
            }
        }

        private void ActivityLevelsLoad()
        {
            DropDownListActivityLevel.DataTextField = "levelName";
            DropDownListActivityLevel.DataValueField = "idActivityLevel";
            DropDownListActivityLevel.DataSource = BLL_EventLog.GetActivityLevels();
            DropDownListActivityLevel.DataBind();
        }

        private void ActivitysLoad()
        {
            DropDownListActivity.DataTextField = "activity";
            DropDownListActivity.DataValueField = "idActivity";
            DropDownListActivity.DataSource = BLL_EventLog.GetActivitys();
            DropDownListActivity.DataBind();
        }

        private void UpdateGV()
        {
            gvEventLog.DataSource = BLL_EventLog.GetEventLog();
            gvEventLog.DataBind();
        }

        protected void gvEventLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEventLog.PageIndex = e.NewPageIndex;
            if (ViewState["eventLogFilter"] != null)
            {
                DataTable table = BLL_EventLog.GetEventLog();
                DataView view = new DataView(table);
                string filter = ViewState["eventLogFilter"].ToString();
                view.RowFilter = filter;
                gvEventLog.DataSource = view;
                gvEventLog.DataBind();
            }
            else
            {
                UpdateGV();
            }
        }

        protected void CheckBoxUsername_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxUsername.Enabled = CheckBoxUsername.Checked;
        }

        protected void CheckBoxActivity_CheckedChanged(object sender, EventArgs e)
        {
            DropDownListActivity.Enabled = CheckBoxActivity.Checked;
        }

        protected void CheckBoxActivityLevel_CheckedChanged(object sender, EventArgs e)
        {
            DropDownListActivityLevel.Enabled = CheckBoxActivityLevel.Checked;
        }

        protected void CheckBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            DateTimeStart.Enabled = CheckBoxDate.Checked;
            DateTimeEnd.Enabled = CheckBoxDate.Checked;
        }

        protected void ButtonFilter_Click(object sender, EventArgs e)
        {
            //CAMBIAR LA LOGICA... NO ES LO MEJOR
            UpdateGVFilter();
        }

        private void UpdateGVFilter()
        {
            DataTable table = BLL_EventLog.GetEventLog();
            DataView view = new DataView(table);
            string filter = "1=1";
            if (CheckBoxUsername.Checked && !string.IsNullOrEmpty(TextBoxUsername.Text))
            {
                filter += $" AND Usuario = '{TextBoxUsername.Text}'";
            }
            if (CheckBoxActivity.Checked)
            {
                filter += $" AND Actividad = '{DropDownListActivity.SelectedItem.Text}'";
            }
            if (CheckBoxActivityLevel.Checked)
            {
                filter += $" AND Nivel = '{DropDownListActivityLevel.SelectedItem.Text}'";
            }
            if (CheckBoxDate.Checked && !string.IsNullOrEmpty(DateTimeStart.Text) && !string.IsNullOrEmpty(DateTimeEnd.Text))
            {
                DateTime startDate = DateTime.Parse(DateTimeStart.Text);
                DateTime endDate = DateTime.Parse(DateTimeEnd.Text);
                filter += $" AND Fecha >= '{startDate:yyyy-MM-dd}' AND Fecha <= '{endDate:yyyy-MM-dd}'";
            }
            ViewState["eventLogFilter"] = filter;
            view.RowFilter = filter;
            gvEventLog.DataSource = view;
            gvEventLog.DataBind();
        }
    }
}