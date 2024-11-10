using BLL;
using SERVICES;
using SERVICES.Languages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace UI.Webforms
{
    public partial class frmEventLog : System.Web.UI.Page, IObserver
    {
        private DataTable eventLogOriginal = BLL_EventLog.GetEventLog();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObservableLanguage.Attach(this);
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
            gvEventLog.DataSource = eventLogOriginal;
            gvEventLog.DataBind();
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
            UpdateGVFilter();
        }

        private void UpdateGVFilter()
        {
            DataTable table = eventLogOriginal;
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