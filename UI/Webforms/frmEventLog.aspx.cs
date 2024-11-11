using BLL;
using SERVICES;
using SERVICES.Languages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.WebService;

namespace UI.Webforms
{
    public partial class frmEventLog : System.Web.UI.Page, IObserver
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObservableLanguage.Attach(this);
                ViewState["EventLogData"] = BLL_EventLog.GetEventLog();
                ViewState["EventLogDataFiltered"] = ViewState["EventLogData"];
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
            gvEventLog.DataSource = ViewState["EventLogData"];
            gvEventLog.DataBind();
        }
        protected void CheckBoxUsername_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxUsername.Enabled = CheckBoxUsername.Checked;
            if (!CheckBoxUsername.Checked)
            {
                TextBoxUsername.Text = string.Empty;
                UpdateGVFilter();
            }
        }
        protected void CheckBoxActivity_CheckedChanged(object sender, EventArgs e)
        {
            DropDownListActivity.Enabled = CheckBoxActivity.Checked;
            if (!(sender as CheckBox).Checked) UpdateGVFilter();
        }

        protected void CheckBoxActivityLevel_CheckedChanged(object sender, EventArgs e)
        {
            DropDownListActivityLevel.Enabled = CheckBoxActivityLevel.Checked;
        }

        protected void CheckBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            DateTimeStart.Enabled = CheckBoxDate.Checked;
            DateTimeEnd.Enabled = CheckBoxDate.Checked;
            if (!CheckBoxDate.Checked)
            {
                DateTimeStart.Text = string.Empty;
                DateTimeEnd.Text = string.Empty;
                UpdateGVFilter();
            }
        }

        protected void ButtonFilter_Click(object sender, EventArgs e)
        {
            UpdateGVFilter(true);
        }
        protected void ButtonDownloadXml_Click(object sender, EventArgs e)
        {
            WebServiceEventLog svc = new WebServiceEventLog();
            int startRow = gvEventLog.PageIndex * gvEventLog.PageSize;
            int endRow = startRow + gvEventLog.PageSize - 1;
            Response.Clear();
            Response.ContentType = "application/xml";
            Response.AddHeader("Content-Disposition", "attachment; filename=eventlog.xml");
            Response.Write(svc.ConvertDataTableToXML((DataTable)ViewState["EventLogDataFiltered"]));
            Response.End();
        }
        protected void gvEventLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEventLog.PageIndex = e.NewPageIndex;
            UpdateGVFilter();
        }

        private void UpdateGVFilter(bool flag = false)
        {
            try
            {
                if (flag)
                {
                    if (!CheckBoxUsername.Checked && !CheckBoxActivity.Checked && !CheckBoxActivityLevel.Checked && !CheckBoxDate.Checked)
                    {
                        throw new Exception("Por favor, seleccione al menos un filtro.");
                    }
                    gvEventLog.PageIndex = 0;
                }
                DataTable table = ViewState["EventLogData"] as DataTable;
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
                view.RowFilter = filter;
                gvEventLog.DataSource = view;
                gvEventLog.DataBind();
                ViewState["EventLogDataFiltered"] = view.ToTable();

            }
            catch (Exception ex)
            {
                WebformMessage.ShowMessage(ex.Message, this);
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
    }
}