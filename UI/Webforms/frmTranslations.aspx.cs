using BLL;
using SERVICES;
using SERVICES.Languages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UI.Webforms
{
    public partial class frmTranslations : System.Web.UI.Page, IObserver
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LanguageLoad();
                WebformsLoad();
                UpdateGV();
                ObservableLanguage.Attach(this);
            }
        }

        private void WebformsLoad()
        {
            DataTable webforms = BLL_Language.GetAllWebforms();
            DropDownListWebform.DataTextField = "webformName";
            DropDownListWebform.DataValueField = "webformName";
            DropDownListWebform.DataSource = webforms;
            DropDownListWebform.DataBind();
        }

        private DataTable languages = BLL_Language.GetLanguages();
        private void LanguageLoad()
        {
            DropDownListFromLanguage.DataTextField = "languageDisplay";
            DropDownListFromLanguage.DataValueField = "idLanguage";
            DropDownListFromLanguage.DataSource = languages;
            DropDownListFromLanguage.DataBind();
            //las 2 ddl
            DropDownListToLanguage.DataTextField = "languageDisplay";
            DropDownListToLanguage.DataValueField = "idLanguage";
            DropDownListToLanguage.DataSource = languages;
            DropDownListToLanguage.DataBind();

            DropDownListFromLanguage.SelectedIndex = -1;
        }

        protected void DropDownListFromLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageLoad();
            ListItem selectedItem = DropDownListFromLanguage.SelectedItem;

            if (selectedItem != null)
            {
                DropDownListToLanguage.Items.Remove(selectedItem);
            }
        }

        protected void DropDownListToLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvLanguage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvLanguage.EditIndex = e.NewEditIndex;
        }

        protected void gvLanguage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvLanguage.EditIndex = -1;
        }

        protected void gvLanguage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // pks de lo que voy a editar
            string key1 = gvLanguage.DataKeys[e.RowIndex].Values["controlName"].ToString();
            string key2 = gvLanguage.DataKeys[e.RowIndex].Values["webformName"].ToString();

            DataTable table = ViewState["languageTable"] as DataTable;

            // nuevo valor
            if (table != null)
            {
                // Obtener el nuevo valor del TextBox en la fila editada
                GridViewRow row = gvLanguage.Rows[e.RowIndex];
                string newValue = ((TextBox)row.Cells[table.Columns.Count].Controls[0]).Text;//sin -1 por los 2 botones que se agregan

                // Filtrar la fila correspondiente usando las claves primarias
                DataRow[] rows = table.Select($"controlName = '{key1}' AND webformName = '{key2}'");

                if (rows.Length > 0)
                {
                    // Actualizar el valor de la columna correspondiente
                    rows[0][table.Columns.Count - 1] = newValue;
                }

                // Salir del modo de edición
                gvLanguage.EditIndex = -1;

                // Actualizar el ViewState con la tabla modificada
                ViewState["languageTable"] = table;

                // Volver a enlazar el GridView
                gvLanguage.DataSource = table;
                gvLanguage.DataBind();
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            DataTable table = ViewState["languageTable"] as DataTable;
            Translation.SaveTranslation(table);
            ObservableLanguage.CurrentLanguage = ObservableLanguage.CurrentLanguage;// trampa para actualizar los forms... corregir dps
        }

        public List<Control> GetAllWebControls(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control control in parent.Controls)
            {
                if (control is WebControl)
                {
                    WebControl webControl = (WebControl)control;
                    controls.Add(webControl);
                }
                if (control is HtmlControl htmlControl)
                {
                    controls.Add(htmlControl);
                }
                if (control.HasControls())
                {
                    controls.AddRange(GetAllWebControls(control));
                }
            }
            return controls;
        }


        public void Translate()
        {
            List<Control> controlList = GetAllWebControls(this);

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

        protected void CheckBoxWebform_CheckedChanged(object sender, EventArgs e)
        {
            DropDownListWebform.Enabled = CheckBoxWebform.Checked;
        }

        private void UpdateGV()
        {
            DataTable table = Translation.GetTranslationTable();
            gvLanguage.DataSource = table;
            ViewState["languageTable"] = table;
            gvLanguage.DataBind();
        }

        protected void ButtonFilter_Click(object sender, EventArgs e)
        {
            DataTable table = Translation.GetTranslationTable();
            DataView view = new DataView(table);
            string filter = "1=1";
            if (CheckBoxNull.Checked)
            {
                int lastColumn = -1;
                if (gvLanguage.Rows.Count > 0)
                {
                    foreach (TableCell cell in gvLanguage.Rows[0].Cells)
                    {
                        lastColumn++;
                    }
                    string lastColumnName = gvLanguage.HeaderRow.Cells[lastColumn].Text;
                    filter += $" AND `{lastColumnName}` IS NULL OR `{lastColumnName}` = '' OR `{lastColumnName}` = '&nbsp;'";
                }
            }
            if (CheckBoxWebform.Checked)
            {
                filter += $" AND webformName = '{DropDownListWebform.SelectedItem.Text}'";
            }
            ViewState["languageFilter"] = filter;
            view.RowFilter = filter;
            gvLanguage.DataSource = view;
            gvLanguage.DataBind();

        }
    }
}